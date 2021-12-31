
import re

fact_re = r'\[<Fact\((.*?)\]'
list_arg_re = r'= \[(.*?)\]'
second_arg_re = r'(".*?") \|>'
expected_re = r'equal \[(.*?)\]|Empty'
desc_re = r'let "(.*?)"'
method_name = 'findAnagrams'

test_head = """
module PhoneNumberTests =
    open Fuchu
    open PhoneNumber


    let suite =
        testList
            "PhoneNumber Suite"
            [ testList
                "PhoneNumber Clean tests"
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

with open('AnagramTest.fs') as inp:
    text = inp.read()
    text = re.sub(fact_re, "", text)
    test_cases = re.split(r'\n{2}', text)
    for c in test_cases:
        print(c)
        # continue
        desc = re.search(desc_re, c).group(1)
        expected_match = re.search(expected_re, c)
        if 'equal' in expected_match.group(0):
            expected = f'[{expected_match.group(1)}]'
        else:
            expected = '[]'

        list_arg = f'[{re.search(list_arg_re, c).group(1)}]'
        second_arg = re.search(second_arg_re, c).group(1)

        actual = f'{method_name} {list_arg} {second_arg})'

        new_test_case = test_case.replace('{description}', desc).replace(
            '{expected}', expected).replace('{actual}', actual)
        test_head += new_test_case
    test_head += test_tail

    with open('GenTest.fs', 'w') as out:
        out.write(test_head)
