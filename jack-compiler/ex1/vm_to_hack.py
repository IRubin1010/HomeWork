import os
import ex1.hack_commands as commands
import ex1.helpers as helpers


def compile_vm_to_hack(file_to_compile):
    if os.path.isfile(file_to_compile):
        file_splitted = os.path.splitext(file_to_compile)
        if file_splitted[1] == ".vm":
            file_name = file_splitted[0]
            output_file = "{}.asm".format(file_name)
            parse_vm_to_hack(file_to_compile, output_file)
        else:
            print("file {} is not a .vm file".format(file_to_compile))
    else:
        print("no such file{}".format(file_to_compile))


def parse_vm_to_hack(file_to_parse_name_path, output_file_name_path):
    compare_arithmetic_label_counter = 0
    file_name = os.path.basename(file_to_parse_name_path)[:-3]

    with open(file_to_parse_name_path, 'r') as input_file:
        with open(output_file_name_path, 'w') as output_file:

            output_file.write("//bootstrap\n")
            output_file.write(commands.stack_init_commands)

            for line in input_file:
                command = line.split()
                if line.startswith("//") or command == []:
                    continue

                if "//" in command:
                    command = command[0:command.index("//")]

                print(command)
                command_length = len(command)
                formatted_command = ' '.join(command)

                if command_length == 1:
                    arithmetic_command = command[0]

                    if arithmetic_command == "add":
                        output_file.write("\n//add\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="+"))

                    elif arithmetic_command == "sub":
                        output_file.write("\n//sub\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="-"))

                    elif arithmetic_command == "neg":
                        output_file.write("\n//neg\n")
                        output_file.write(commands.stack_unary_arithmetic_command.format(operator="-"))

                    elif arithmetic_command == "eq":
                        output_file.write("\n//eq\n")
                        output_file.write(commands.stack_compare_arithmetic_command.format(comparer="JEQ",
                                                                                           x=compare_arithmetic_label_counter))
                        compare_arithmetic_label_counter += 1

                    elif arithmetic_command == "gt":
                        output_file.write("\n//gt\n")
                        output_file.write(commands.stack_compare_arithmetic_command.format(comparer="JGT",
                                                                                           x=compare_arithmetic_label_counter))
                        compare_arithmetic_label_counter += 1

                    elif arithmetic_command == "lt":
                        output_file.write("\n//lt\n")
                        output_file.write(commands.stack_compare_arithmetic_command.format(comparer="JLT",
                                                                                           x=compare_arithmetic_label_counter))
                        compare_arithmetic_label_counter += 1

                    elif arithmetic_command == "and":
                        output_file.write("\n//and\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="&"))

                    elif arithmetic_command == "or":
                        output_file.write("\n//or\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="|"))

                    elif arithmetic_command == "not":
                        output_file.write("\n//not\n")
                        output_file.write(commands.stack_unary_arithmetic_command.format(operator="!"))

                    else:
                        raise Exception("syntax error at {}.".format(formatted_command))

                elif command_length == 3:
                    command_name = command[0]
                    command_type = command[1]
                    command_parameter = command[2]

                    is_parameter_int, value = helpers.int_try_parse(command_parameter)
                    if not is_parameter_int:
                        raise Exception("syntax error at {}.".format(formatted_command))

                    if command_name == "push":

                        if command_type in ['local', 'this', 'that', 'argument']:
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_push_lcl_arg_this_that_command.format(x=command_parameter,
                                                                                                   register=helpers.map_to_lcl_arg_this_that(
                                                                                                       command_type)))

                        elif command_type == 'temp':
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_push_temp_command.format(x=command_parameter))

                        elif command_type == 'static':
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_push_static_command.format(x=command_parameter,
                                                                                        class_name=file_name))

                        elif command_type == 'pointer':

                            if command_parameter == 0:
                                output_file.write("\n//{}\n".format(formatted_command))
                                output_file.write(commands.stack_push_pointer_0_command)

                            elif command_parameter == 1:
                                output_file.write("\n//{}\n".format(formatted_command))
                                output_file.write(commands.stack_push_pointer_1_command)

                            else:
                                raise Exception("syntax error at {}.".format(formatted_command))

                        elif command_type == 'constant':
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_push_constant_command.format(x=command_parameter))

                        else:
                            raise Exception("syntax error at {}.".format(formatted_command))

                    elif command_name == "pop":

                        if command_type in ['local', 'this', 'that', 'argument']:
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_pop_lcl_arg_this_that_command.format(x=command_parameter,
                                                                                                  register=helpers.map_to_lcl_arg_this_that(
                                                                                                      command_type)))

                        elif command_type == 'temp':
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_pop_temp_command.format(x=command_parameter))

                        elif command_type == 'static':
                            output_file.write("\n//{}\n".format(formatted_command))
                            output_file.write(commands.stack_pop_static_command.format(x=command_parameter,
                                                                                       class_name=file_name))

                        elif command_type == 'pointer':

                            if command_parameter == 0:
                                output_file.write("\n//{}\n".format(formatted_command))
                                output_file.write(commands.stack_pop_pointer_0_command)

                            elif command_parameter == 1:
                                output_file.write("\n//{}\n".format(formatted_command))
                                output_file.write(commands.stack_pop_pointer_1_command)

                            else:
                                raise Exception("syntax error at {}.".format(formatted_command))

                        else:
                            raise Exception("syntax error at {}.".format(formatted_command))

                    else:
                        raise Exception("syntax error at {}.".format(formatted_command))

                else:
                    raise Exception("syntax error at {}.".format(formatted_command))


compile_vm_to_hack(os.getcwd() + "\\tests\\MemoryAccess\\StaticTest\\StaticTest.vm")
