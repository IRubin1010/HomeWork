import os
import re

keywords = ["class", "constructor", "function", "method", "field", "static", "var", "int", "char",
            "boolean", "void", "true", "false", "null", "this", "let", "do", "if", "else", "while", "return"]

symbols = ["{", "}", "(", ")", "[", "]", ".", ",", ";", "+", "-", "*", "/", "&", "|", "<", ">", "=", "~"]


def split_tight_words(text):
    for ch in symbols:
        if ch in text:
            text = text.replace(ch, " {} ".format(ch))
    return text


def split_line(line):
    splitted_line = line.split()
    s = []
    for word in splitted_line:
        if is_string(word):
            s.append(word)
        else:
            s.extend(split_tight_words(word).split())
    return s


def is_integer(number):
    try:
        int_val = int(number)
        return 0 <= int_val <= 32767
    except:
        return False


def is_string(word):
    if word.startswith('"') and word.endswith('"'):
        return True
    return False


def is_identifier(word):
    if re.match("^[A-Za-z0-9_]*$", word) and not re.match("^[0-9_]*$", word[:1]):
        return True
    return False


def replace_strings(line):
    strings = re.findall('"([^"]*)"', line)
    for s in strings:
        line = line.replace(s, s.replace(" ", "_"))
    return line

def replace_special_symbols(symbol):
    if symbol == "<":
        return "&lt;"
    elif symbol == ">":
        return "&gt;"
    elif symbol == '"':
        return "&qout;"
    elif symbol == "&":
        return "&amp;"
    else:
        return symbol


def tokenize_directory(directory_to_tokenize):
    if os.path.isdir(directory_to_tokenize):
        for file in os.listdir(directory_to_tokenize):
            file_splitted = os.path.splitext(file)
            if file_splitted[1] == ".jack":
                print("converting:  " + directory_to_tokenize + '\\' + file)
                tokenize_file(directory_to_tokenize + '\\' + file)
    else:
        print("no such directory {}".format(directory_to_tokenize))


def tokenize_file(file_to_tokenize_path_name):
    output_file_path_name = file_to_tokenize_path_name[:-5] + "_T.xml"

    with open(file_to_tokenize_path_name, 'r') as input_file:
        with open(output_file_path_name, 'w') as output_file:
            output_file.write("<tokens>\n")
            for line in input_file:

                # remove line comments end empty lines
                if line.lstrip().startswith(("//", "/**", "*", "*/")) or not line.lstrip():
                    continue

                # remove inline comments
                line = line[0:line.find("//")]

                # mark strings
                line = replace_strings(line)

                # split line
                line_command = split_line(line)
                print(line_command)

                for word in line_command:
                    if word in keywords:
                        output_file.write("\t<keyword>")
                        output_file.write(" {} ".format(word))
                        output_file.write("</keyword>\n")
                    elif word in symbols:
                        output_file.write("\t<symbol>")
                        output_file.write(" {} ".format(replace_special_symbols(word)))
                        output_file.write("</symbol>\n")
                    elif is_integer(word):
                        output_file.write("\t<integerConstant>")
                        output_file.write(" {} ".format(word))
                        output_file.write("</integerConstant>\n")
                    elif is_string(word):
                        output_file.write("\t<stringConstant>")
                        output_file.write(" {} ".format(word.replace('"', '').replace('_', " ")))
                        output_file.write("</stringConstant>\n")
                    elif is_identifier(word):
                        output_file.write("\t<identifier>")
                        output_file.write(" {} ".format(word))
                        output_file.write("</identifier>\n")

            output_file.write("</tokens>\n")


tokenize_directory(os.getcwd() + "\\tests\\Square")
