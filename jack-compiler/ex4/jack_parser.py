import os
import xml.etree.ElementTree as ET

number_of_tab_spaces = 0


def match_token(input_file, output_file, token_type, token_text_list, peek_only=False):
    line = peek_line(input_file)
    line_root = ET.ElementTree(ET.fromstring(line)).getroot()
    file_token_type = line_root.tag
    file_token_text = line_root.text.strip()
    if not file_token_type == token_type or (len(token_text_list) != 0 and file_token_text not in token_text_list):
        return False
    token_str = ET.tostring(line_root).decode()
    if not peek_only:
        print_token(output_file, token_str)
        input_file.readline()
    return True


def match_next_token(input_file, token_type, token_text_list):
    line = peek_next_line(input_file)
    line_root = ET.ElementTree(ET.fromstring(line)).getroot()
    file_token_type = line_root.tag
    file_token_text = line_root.text.strip()
    if not file_token_type == token_type or (len(token_text_list) != 0 and file_token_text not in token_text_list):
        return False
    return True


def peek_line(f):
    pos = f.tell()
    line = f.readline()
    f.seek(pos)
    return line


def peek_next_line(f):
    pos = f.tell()
    f.readline()
    line = f.readline()
    f.seek(pos)
    return line


def print_token(output_file, token):
    formatted_token = "{spaces}{token}\n".format(spaces="  " * number_of_tab_spaces, token=token)
    output_file.write(formatted_token)


def parse_directory(directory_to_tokenize):
    if os.path.isdir(directory_to_tokenize):
        for file in os.listdir(directory_to_tokenize):
            if file.endswith("_T.xml"):
                print("converting:  " + directory_to_tokenize + '\\' + file)
                parse_file(directory_to_tokenize + '\\' + file)
    else:
        print("no such directory {}".format(directory_to_tokenize))


def parse_file(file_to_tokenize_path_name):
    output_file_path_name = file_to_tokenize_path_name[:-6] + "_test.xml"

    with open(file_to_tokenize_path_name, 'r') as input_file:
        with open(output_file_path_name, 'w') as output_file:
            input_file.readline()
            global number_of_tab_spaces
            number_of_tab_spaces = 0
            parse_class(input_file, output_file)


def parse_class(input_file, output_file):
    is_class = match_token(input_file, output_file, "keyword", ["class"], True)
    if is_class:
        print_token(output_file, "<class>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["class"])
        parse_class_name(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["{"])
        parse_class_var_dec(input_file, output_file)
        parse_sub_routine_dec(input_file, output_file)
        match_token(input_file, output_file, "symbol", "}")

        number_of_tab_spaces -= 1
        print_token(output_file, "</class>")


def parse_class_var_dec(input_file, output_file):
    is_class_var_dec = match_token(input_file, output_file, "keyword", ["static", "field"], True)
    if is_class_var_dec:
        print_token(output_file, "<classVarDec>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["static", "field"])
        parse_var(input_file, output_file)

        number_of_tab_spaces -= 1
        print_token(output_file, "</classVarDec>")
        parse_class_var_dec(input_file, output_file)


def parse_type(input_file, output_file):
    if match_token(input_file, output_file, "keyword", ["int", "char", "boolean"]):
        return True
    elif match_token(input_file, output_file, "identifier", []):
        return True
    return False


def parse_sub_routine_dec(input_file, output_file):
    is_class_sub_routine_dec = match_token(input_file, output_file, "keyword", ["constructor", "function", "method"],
                                           True)
    if is_class_sub_routine_dec:
        print_token(output_file, "<subroutineDec>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["constructor", "function", "method"])
        if not parse_type(input_file, output_file):
            match_token(input_file, output_file, "keyword", ["void"])
        parse_sub_routine_name(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["("])
        parse_parameter_list(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])
        parse_sub_routine_body(input_file, output_file)

        number_of_tab_spaces -= 1
        print_token(output_file, "</subroutineDec>")
        parse_sub_routine_dec(input_file, output_file)


def parse_parameter_list(input_file, output_file):
    print_token(output_file, "<parameterList>")
    global number_of_tab_spaces
    number_of_tab_spaces += 1

    parse_type(input_file, output_file)
    parse_var_name(input_file, output_file)
    while match_token(input_file, output_file, "symbol", [","]):
        parse_type(input_file, output_file)
        parse_var_name(input_file, output_file)

    number_of_tab_spaces -= 1
    print_token(output_file, "</parameterList>")


def parse_sub_routine_body(input_file, output_file):
    is_sub_routine_body = match_token(input_file, output_file, "symbol", ["{"], True)
    if is_sub_routine_body:
        print_token(output_file, "<subroutineBody>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "symbol", ["{"])
        parse_var_dec(input_file, output_file)
        parse_statements(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["}"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</subroutineBody>")


def parse_var_dec(input_file, output_file):
    is_var_dec = match_token(input_file, output_file, "keyword", ["var"], True)
    if is_var_dec:
        print_token(output_file, "<varDec>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["var"])
        parse_var(input_file, output_file)

        number_of_tab_spaces -= 1
        print_token(output_file, "</varDec>")
        parse_var_dec(input_file, output_file)


def parse_class_name(input_file, output_file):
    if match_token(input_file, output_file, "identifier", []):
        return True
    return False


def parse_sub_routine_name(input_file, output_file):
    if match_token(input_file, output_file, "identifier", []):
        return True
    return False


def parse_var_name(input_file, output_file):
    if match_token(input_file, output_file, "identifier", []):
        return True
    return False


def parse_statements(input_file, output_file):
    print_token(output_file, "<statements>")
    global number_of_tab_spaces
    number_of_tab_spaces += 1

    parse_statement(input_file, output_file)

    number_of_tab_spaces -= 1
    print_token(output_file, "</statements>")


def parse_statement(input_file, output_file):

    is_statement = parse_let_statement(input_file, output_file) \
        or parse_if_statement(input_file, output_file) \
        or parse_while_statement(input_file, output_file) \
        or parse_do_statement(input_file, output_file) \
        or parse_return_statement(input_file, output_file)

    if not is_statement:
        return
    parse_statement(input_file, output_file)


def parse_let_statement(input_file, output_file):
    is_let_statement = match_token(input_file, output_file, "keyword", ["let"], True)
    if is_let_statement:
        print_token(output_file, "<letStatement>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["let"])
        parse_var_name(input_file, output_file)
        if match_token(input_file, output_file, "symbol", ["["]):
            parse_expression(input_file, output_file)
            match_token(input_file, output_file, "symbol", ["]"])
        match_token(input_file, output_file, "symbol", ["="])
        parse_expression(input_file, output_file)
        match_token(input_file, output_file, "symbol", [";"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</letStatement>")
        return True
    return False


def parse_if_statement(input_file, output_file):
    is_if_statement = match_token(input_file, output_file, "keyword", ["if"], True)
    if is_if_statement:
        print_token(output_file, "<ifStatement>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["if"])
        match_token(input_file, output_file, "symbol", ["("])
        parse_expression(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])
        match_token(input_file, output_file, "symbol", ["{"])
        parse_statements(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["}"])

        if match_token(input_file, output_file, "keyword", ["else"]):
            match_token(input_file, output_file, "symbol", ["{"])
            parse_statements(input_file, output_file)
            match_token(input_file, output_file, "symbol", ["}"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</ifStatement>")
        return True
    return False


def parse_while_statement(input_file, output_file):
    is_while_statement = match_token(input_file, output_file, "keyword", ["while"], True)
    if is_while_statement:
        print_token(output_file, "<whileStatement>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["while"])
        match_token(input_file, output_file, "symbol", ["("])
        parse_expression(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])
        match_token(input_file, output_file, "symbol", ["{"])
        parse_statements(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["}"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</whileStatement>")
        return True
    return False


def parse_do_statement(input_file, output_file):
    is_do_statement = match_token(input_file, output_file, "keyword", ["do"], True)
    if is_do_statement:
        print_token(output_file, "<doStatement>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["do"])
        parse_sub_routine_call(input_file, output_file)
        match_token(input_file, output_file, "symbol", [";"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</doStatement>")
        return True
    return False


def parse_return_statement(input_file, output_file):
    is_return_statement = match_token(input_file, output_file, "keyword", ["return"], True)
    if is_return_statement:
        print_token(output_file, "<returnStatement>")
        global number_of_tab_spaces
        number_of_tab_spaces += 1

        match_token(input_file, output_file, "keyword", ["return"])
        if not match_token(input_file, output_file, "symbol", [";"]):
            parse_expression(input_file, output_file)
            match_token(input_file, output_file, "symbol", [";"])

        number_of_tab_spaces -= 1
        print_token(output_file, "</returnStatement>")
        return True
    return False


def parse_expression(input_file, output_file):
    print_token(output_file, "<expression>")
    global number_of_tab_spaces
    number_of_tab_spaces += 1

    parse_term(input_file, output_file)
    while parse_op(input_file, output_file):
        parse_term(input_file, output_file)

    number_of_tab_spaces -= 1
    print_token(output_file, "</expression>")
    return True


def parse_term(input_file, output_file):
    print_token(output_file, "<term>")
    global number_of_tab_spaces
    number_of_tab_spaces += 1

    is_parsed = match_token(input_file, output_file, "integerConstant", [])
    if not is_parsed:
        is_parsed = match_token(input_file, output_file, "stringConstant", [])
    if not is_parsed:
        is_parsed = parse_keyword_constant(input_file, output_file)
    if not is_parsed:
        if match_token(input_file, output_file, "identifier", [], True):
            if match_next_token(input_file, "symbol", ["("]) or match_next_token(input_file, "symbol", ["."]):
                is_parsed = parse_sub_routine_call(input_file, output_file)
            else:
                is_parsed = parse_term_var_name(input_file, output_file)
        else:
            is_parsed = False
    if not is_parsed and match_token(input_file, output_file, "symbol", ["("]):
        parse_expression(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])
        is_parsed = True
    if not is_parsed and parse_unary_op(input_file, output_file):
        parse_term(input_file, output_file)

    number_of_tab_spaces -= 1
    print_token(output_file, "</term>")
    return True


def parse_sub_routine_call(input_file, output_file):
    if match_next_token(input_file, "symbol", ["("]):
        parse_sub_routine_name(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["("])
        parse_expression_list(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])

    elif match_next_token(input_file, "symbol", ["."]):
        match_token(input_file, output_file, "identifier", [])
        match_token(input_file, output_file, "symbol", ["."])
        parse_sub_routine_name(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["("])
        parse_expression_list(input_file, output_file)
        match_token(input_file, output_file, "symbol", [")"])
    return True


def parse_expression_list(input_file, output_file):
    print_token(output_file, "<expressionList>")
    global number_of_tab_spaces
    number_of_tab_spaces += 1

    if not match_token(input_file, output_file, "symbol", [")"], True):
        parse_expression(input_file, output_file)
        while match_token(input_file, output_file, "symbol", [","]):
            parse_expression(input_file, output_file)

    number_of_tab_spaces -= 1
    print_token(output_file, "</expressionList>")
    return True


def parse_op(input_file, output_file):
    match_token(input_file, output_file, "symbol", ["&lt;"], True)
    return match_token(input_file, output_file, "symbol", ["+"]) \
           or match_token(input_file, output_file, "symbol", ["-"]) \
           or match_token(input_file, output_file, "symbol", ["*"]) \
           or match_token(input_file, output_file, "symbol", ["/"]) \
           or match_token(input_file, output_file, "symbol", ["&"]) \
           or match_token(input_file, output_file, "symbol", ["|"]) \
           or match_token(input_file, output_file, "symbol", ["<"]) \
           or match_token(input_file, output_file, "symbol", [">"]) \
           or match_token(input_file, output_file, "symbol", ["="])


def parse_unary_op(input_file, output_file):
    return match_token(input_file, output_file, "symbol", ["-"]) \
           or match_token(input_file, output_file, "symbol", ["~"])


def parse_keyword_constant(input_file, output_file):
    return match_token(input_file, output_file, "keyword", ["true"]) \
           or match_token(input_file, output_file, "keyword", ["false"]) \
           or match_token(input_file, output_file, "keyword", ["null"]) \
           or match_token(input_file, output_file, "keyword", ["this"])


def parse_term_var_name(input_file, output_file):
    if not parse_var_name(input_file, output_file):
        return False
    if match_token(input_file, output_file, "symbol", ["["]):
        parse_expression(input_file, output_file)
        match_token(input_file, output_file, "symbol", ["]"])
    return True


def parse_var(input_file, output_file):
    parse_type(input_file, output_file)
    parse_var_name(input_file, output_file)
    while match_token(input_file, output_file, "symbol", [","], True):
        match_token(input_file, output_file, "symbol", [","])
        parse_var_name(input_file, output_file)
    match_token(input_file, output_file, "symbol", [";"])


parse_directory(os.getcwd() + "\\tests\\Square")
