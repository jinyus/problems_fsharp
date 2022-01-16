
import re

skip_re = r'\(Skip.*?\)'
fact_re = r'\[<Fact.*?\]'
list_arg_re = r'= \[(.*?)\]'
string_arg_re = r'(proteins) (".*?")'
second_arg_re = r'(".*?") \|>'
expected_re = r'equal (\[.*?\])|Empty'
# expected_re = r'equal (".*?")'
desc_re = r'let "(.*?)"'
method_name = 'decode'
file_name = 'ProteinTranslationTests'

test_head = f"""
module {file_name} =
    open Fuchu
    open ProteinTranslation


    let suite =
        testList
            "ProteinTranslation Suite"
            [ testList
                "ProteinTranslation Translate tests"
                [ 
"""

test_tail = """] ]

            [<EntryPoint>]
            let main _ = run suite
"""

test_case = """
                testCase "{description}"
                <| fun _ -> Assert.Equal("", {expected}, {actual}
"""

with open('test.fs') as inp:
    text = inp.read()
    text = re.sub(fact_re, "", text)
    test_cases = re.split(r'\n{2,}', text)
    for c in test_cases:
        print(c)
        # continue
        desc = re.search(desc_re, c).group(1)
        expected_match = re.search(expected_re, c)
        if 'equal' in expected_match.group(0):
            expected = expected_match.group(1)
        else:
            expected = '[]'

        # list_arg = f'[{re.search(list_arg_re, c).group(1)}]'
        string_arg_match = re.search(string_arg_re, c)
        method_name = string_arg_match.group(1)
        string_arg = string_arg_match.group(2)
        # second_arg = re.search(second_arg_re, c).group(1)

        # actual = f'{method_name} {list_arg} {second_arg})'
        actual = f'{method_name} {string_arg} )'

        new_test_case = test_case.replace('{description}', desc).replace(
            '{expected}', expected).replace('{actual}', actual)
        test_head += new_test_case
    test_head += test_tail

    with open(f'{file_name}.fs', 'w') as out:
        out.write(test_head)
