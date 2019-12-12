# set SP to 256 - the beginning of the stack
stack_init_commands = "//bootstrap\n@256\nD=A\n@sp\nM=D\n"
# 1. @256  -- load value 256 to A - begin of stack
# 2. D=A   -- put 256 in register D
# 3. @SP   -- SP to A
# 4. M=D   -- M[0] (==SP) = 256


# push to top of the stack the value of M[M[LCL] + x] (LCL/ARG/THAI/THAT)
stack_push_lcl_arg_this_that_command = "@{x}\nD=A\n@{register}\nA=M\nA=D+A\nD=M\n@SP\nM=M+1\nA=M-1\nM=D\n"
# 1. @x	   -- load value X to A
# 2. D=A   -- put X into D
# 3. @LCL  -- load LCL address into A
# 4. A=M   -- A = M[LCL]
# 5. A=D+A -- A = M[LCL] + X (stored in D)
# 6. D=M   -- D = M[M[LCL] + x]
# 7. @SP   -- load SP
# 8. M=M+1 -- M[SP] = M[SP] + 1	(SP points to the next cell in stack)
# 9. A=M-1 -- A = M[SP] - 1 (the top cell)
# 10. M=D  -- M[SP-1] = D (M[M[LCL] + x])


# pop the top of the stack into M[M[LCL] + x] (LCL/ARG/THAI/THAT)
stack_pop_lcl_arg_this_that_command = "@{register}\nD=M\n@{x}\nD=D+A\n@13\nM=D\n@SP\nM=M-1\nA=M\nD=M\n@13\nA=M\nM=D\n"
# 1. @LCL  -- load LCL address into A
# 2. D=M   -- D = M[LCL]
# 3. @x	   -- load value x into A
# 4. D=D+A -- D = M[LCL] + x
# 5. @13   -- load custom register 13
# 6. M=D   -- M[13] = D (store M[LCL] in register 13)
# 7. @SP   -- load SP
# 8. M=M-1 -- M[SP] = M[SP] - 1
# 9. A=M   -- A = M[SP]
# 10. D=M  -- D = M[M[SP]] (value of top of stack)
# 11. @13  -- load register value into A (A = M[LCL] + X)
# 12. A=M  -- A = M[LCL] + X
# 13. M=D  -- M[M[LCL] + X] = D (value of top of stack)
