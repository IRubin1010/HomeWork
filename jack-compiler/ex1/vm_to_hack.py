import os

import ex1.hack_commands as commands

file_path = os.path.join(os.getcwd(), "a.asm")
print(file_path)


# with open()
def compile_vm_to_hack(file_to_compile):
    if os.path.isfile(file_to_compile):
        file_splitted = os.path.splitext(file_to_compile)
        if file_splitted[1] == ".vm":
            file_name = file_splitted[0]
            output_file = "{}.test.asm".format(file_name)
            parse_vm_to_hack(file_to_compile, output_file)
        else:
            print("file {} is not a .vm file".format(file_to_compile))
    else:
        print("no such file{}".format(file_to_compile))

    # with open(file_path, 'w') as file:
    #     file.write(commands.stack_push_lcl_arg_this_that_command.format(x=20, register=1))
    # print("aa")


def parse_vm_to_hack(file_to_parse_name, output_file_name):
    with open(file_to_parse_name, 'r') as input_file:
        with open(output_file_name, 'w') as output_file:

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

                if command_length == 1:
                    arithmetic_command = command[0]
                    if arithmetic_command == "add":
                        output_file.write("\n//add\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="+"))
                    elif arithmetic_command == "sub":
                        output_file.write("\n//sub\n")
                        output_file.write(commands.stack_binary_arithmetic_command.format(operator="-"))





compile_vm_to_hack(os.getcwd() + "\\testEmulator\\StackTest.vm")
