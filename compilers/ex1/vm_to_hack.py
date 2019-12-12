import os

import ex1.hack_commands as commands

file_path = os.path.join(os.getcwd(), "a.asm")
print(file_path)


# with open()
def compile_vm_to_hack():
    with open(file_path, 'w') as file:
        file.write(commands.stack_push_lcl_arg_this_that_command.format(x=20, register=1))
    print("aa")


compile_vm_to_hack()
