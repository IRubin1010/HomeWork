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
            for line in input_file:
                if line.startswith("//") or command == []:
                    continue

                command = line.split()

                if "//" in command:
                    command = command[0:command.index("//")]

                print(command)
                command_length = len(command)

                if command_length == 1:
                    arithmetic





compile_vm_to_hack(os.getcwd() + "\\testEmulator\\StackTest.vm")
