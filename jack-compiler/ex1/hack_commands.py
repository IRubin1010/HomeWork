# set SP to 256 - the beginning of the stack
stack_init_commands = "@256\nD=A\n@SP\nM=D\n"
# 1. @256  -- load value 256 to A - begin of stack
# 2. D=A   -- put 256 in register D
# 3. @SP   -- SP to A
# 4. M=D   -- M[0] (==SP) = 256


# push to top of the stack the value of M[M[LCL] + x] (LCL/ARG/THAI/THAT)
stack_push_lcl_arg_this_that_command = "@{x}\nD=A\n@{register}\nA=M\nA=D+A\nD=M\n@SP\nM=M+1\nA=M-1\nM=D\n"
# 1. @x	   -- load value x to A
# 2. D=A   -- put X into D
# 3. @LCL  -- load LCL address into A
# 4. A=M   -- A = M[LCL]
# 5. A=D+A -- A = M[LCL] + X (stored in D)
# 6. D=M   -- D = M[M[LCL] + x]
# 7. @SP   -- load SP
# 8. M=M+1 -- M[SP] = M[SP] + 1	(SP points to the next cell in stack)
# 9. A=M-1 -- A = M[SP] - 1 (the top cell of stack)
# 10. M=D  -- M[SP-1] = D (M[M[LCL] + x])


# pop the top of the stack into M[M[LCL] + x] (LCL/ARG/THAI/THAT)
stack_pop_lcl_arg_this_that_command = "@{register}\nD=M\n@{x}\nD=D+A\n@13\nM=D\n@SP\nM=M-1\nA=M\nD=M\n@13\nA=M\nM=D\n"
# 1. @LCL  -- load LCL address into A
# 2. D=M   -- D = M[LCL]
# 3. @x	   -- load value x into A
# 4. D=D+A -- D = M[LCL] + x
# 5. @13   -- load custom register 13
# 6. M=D   -- M[13] = D (store M[LCL] + x in register 13)
# 7. @SP   -- load SP
# 8. M=M-1 -- M[SP] = M[SP] - 1
# 9. A=M   -- A = M[SP]
# 10. D=M  -- D = M[M[SP]] (value of top of stack)
# 11. @13  -- load register value into A (A = M[LCL] + x)
# 12. A=M  -- A = M[LCL] + x
# 13. M=D  -- M[M[LCL] + x] = D (value of top of stack)

# push to top of the stack value of M[5 + x]
stack_push_temp_command = "@{x}\nD=A\n@5\nA=D+A\nD=M\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @x	   -- load value x to A
# 2. D=A   -- put X into D
# 3. @5    -- load 5 into A
# 4. A=D+A -- A = 5 + x
# 5. D=M   -- D = M[5 + x]
# 6. @SP   -- load SP
# 7. A=M   -- A = M[SP] (top of stack)
# 8. M=D   -- M[M[SP] = D (top of stack = M[5 + x])
# 9. @SP   -- load SP
# 10. M=M+1 -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

# pop the top of the stack into M[5 + x]
stack_pop_temp_command = "@{x}\nD=A\n@5\nD=D+A\n@13\nM=D\n@SP\nM=M-1\nA=M\nD=M\n@13\nA=M\nM=D\n"
# 1. @x	   -- load value x into A
# 2. D=A   -- put X into D
# 3. @5    -- load 5 into A
# 4. D=D+A -- D = 5 + x
# 5. @13   -- load custom register 13
# 6. M=D   -- M[13] = D (store 5 + x in register 13)
# 7. @SP   -- load SP
# 8. M=M-1 -- M[SP] = M[SP] - 1
# 9. A=M   -- A = M[SP]
# 10. D=M  -- D = M[M[SP]] (value of top of stack)
# 11. @13  -- load register value into A (A = M[LCL] + X)
# 12. A=M  -- A = 5 + x
# 13. M=D  -- M[5 + x] = D (value of top of stack)

# push to top of the stack value of M[class_name.x]
stack_push_static_command = "@{class_name}.{x}\nD=M\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @class_name.x  -- load value of class_name.x into A
# 2. D=M		    -- D = M[A] (value of class_name.x)
# 3. @SP		    -- load SP
# 4. A=M		    -- A = M[SP]
# 5. M=D		    -- M[M[SP]] = D
# 6. @SP		    -- load SP
# 7. M=M+1	        -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

# push to top of the stack value of M[class_name.x]
stack_pop_static_command = "@SP\nM=M-1\nA=M\nD=M\n@{class_name}.{x}\nM=D\n"
# 1. @SP		    -- load SP
# 2. M=M-1          -- M[SP] = M[SP] - 1
# 4. A=M		    -- A = M[SP]
# 5. D=M		    -- D = M[M[SP]] (value of top of stack)
# 6. @class_name.x  -- load class_name.x
# 7. M=D		    -- M[class_name.x] = D

# push to top of the stack value of M[THIS]
stack_push_pointer_0_command = "@3\nD=M\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @3    -- load 3 into A (THIS)
# 2. D=M   -- D = M[THIS]
# 3. @SP   -- load SP
# 4. A=M   -- A = M[SP] (top of stack)
# 5. M=D   -- M[M[SP] = D (top of stack = M[THIS])
# 6. @SP   -- load SP
# 7. M=M+1 -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

# pop the top of the stack into M[THIS]
stack_pop_pointer_0_command = "@SP\nM=M-1\nA=M\nD=M\n@3\nM=D\n"
# 1. @SP   -- load SP
# 2. M=M-1 -- M[SP] = M[SP] - 1
# 4. A=M   -- A = M[SP]
# 5. D=M   -- D = M[M[SP]] (value of top of stack)
# 6. @3    -- load 3 (THIS)
# 7. M=D   -- M[THIS] = D

# push to top of the stack value of M[THAT]
stack_push_pointer_1_command = "@4\nD=M\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @4    -- load 3 into A (THAT)
# 2. D=M   -- D = M[THAT]
# 3. @SP   -- load SP
# 4. A=M   -- A = M[SP] (top of stack)
# 5. M=D   -- M[M[SP] = D (top of stack = M[THAT])
# 6. @SP   -- load SP
# 7. M=M+1 -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

# pop the top of the stack into M[THAT]
stack_pop_pointer_1_command = "@SP\nM=M-1\nA=M\nD=M\n@4\nM=D\n"
# 1. @SP   -- load SP
# 2. M=M-1 -- M[SP] = M[SP] - 1
# 4. A=M   -- A = M[SP]
# 5. D=M   -- D = M[M[SP]] (value of top of stack)
# 6. @4    -- load 3 (THAT)
# 7. M=D   -- M[THAT] = D

# push to top of the stack value of a constant
stack_push_constant_command = "@{x}\nD=A\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @x    -- load value x into A
# 2. D=A   -- D = A
# 3. @SP   -- load SP
# 4. A=M   -- A = M[SP] (top of stack)
# 5. M=D   -- M[M[SP] = D (top of stack = constant)
# 6. @SP   -- load SP
# 7. M=M+1 -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

# binary arithmetic e.g. x + y (operators are: +,-,&,|)
stack_binary_arithmetic_command = "@SP\nM=M-1\nA=M\nD=M\nA=A-1\nM=M{operator}D\n"
# 1. @SP            -- load SP
# 2. M=M-1          -- M[SP] = M[SP] - 1
# 4. A=M            -- A = M[SP]
# 5. D=M            -- D = M[M[SP]] (value of top of stack)
# 6. A=A-1          -- A = A - 1 (location of previous cell in stack)
# 7. M=M{operator}D -- M[SP - 1] = M[SP - 1] op D (where op is +,-,&,|)

# unary arithmetic e.g. -x (operators are: -,!)
stack_unary_arithmetic_command = "@SP\nA=M\nA=A-1\nM={operator}M\n"
# 1. @SP           -- load SP
# 4. A=M           -- A = M[SP]
# 6. A=A-1         -- A = A - 1 (location of previous cell in stack)
# 7. M={operator}M -- M[SP - 1] = op M[SP - 1] (where op is -,!)

# compare arithmetic (comparers are JGT,JLT,JEQ)
stuck_compare_arithmetic_command = "@SP\nM=M-1\nA=M\nD=M\nA=A-1\nD=M-D\n@LABEL_{x}\nD;{" \
                                   "comparer}\n@SP\nA=M-1\nM=0\n@END_{x}\n0;JMP\n(LABEL_{x})\n@SP\nA=M-1\nM=-1\n(" \
                                   "END_{x})\n "
# 1. @SP          -- load SP
# 2. M=M-1        -- reduce SP tp previous cell in stack (SP--)
# 3. A=M          -- A = M[SP]
# 4. D=M          -- D = M[M[SP]] (value of top of stack)
# 5. A=A-1        -- A = A - 1 (location of previous cell in stack)
# 6. D=M-D        -- D = M[M[SP - 1]] - M[M[SP]]
# 7. @LABEL_{x}   -- load label into A
# 8. D;{comparer} -- if D comparer 0 - jump to LABEL_{x}
# 9. @SP          -- else - load SP
# 10. A=M-1       -- A = M[SP]
# 11. M=0         -- M[M[SP]] = 0 - false
# 12. @END_{x}    -- load end into A
# 13. 0;JMP       -- jump to end
# 14. (LABEL_{x}) -- definition of label
# 15. @SP         -- load SP
# 16. A=M-1       -- A = M[SP]
# 17. M=-1        -- M[M[SP]] = 1 - true
# 18. (END_{x})	  -- end label
