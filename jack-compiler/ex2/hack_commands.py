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

# push to top of the stack value of a segment (segment can be LCL\ARG\THIS\THAT)
stack_push_segment_command = "@{segment}\nD=M\n@SP\nA=M\nM=D\n@SP\nM=M+1\n"
# 1. @segment    -- load value segment into A
# 2. D=M         -- D = M[LCL] (LCL\ARG\THIS\THAT)
# 3. @SP         -- load SP
# 4. A=M         -- A = M[SP] (top of stack)
# 5. M=D         -- M[M[SP] = D (top of stack = segment)
# 6. @SP         -- load SP
# 7. M=M+1       -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)

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
stack_compare_arithmetic_command = "@SP\nM=M-1\nA=M\nD=M\nA=A-1\nD=M-D\n@LABEL_{x}\nD;{" \
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

# set a label
label_by_file_name_command = "({file_name}.{label_name})\n"
# 1. (file_name.label_name)

# set a label
label_command = "({label_name})\n"
# 1. (label_name)

# jump to label
go_to_label_by_file_name_command = "@{file_name}.{label_name}\n0; JMP\n"
# 1. @{file_name}.{label_name} -- load label file_name.label_name into A
# 2. 0; JMP                    -- jump to label

# jump to label
go_to_label_command = "@{label_name}\n0; JMP\n"
# 1. @{label_name} -- load label into A
# 2. 0; JMP        -- jump to label

# jump to label if top of stack != 0
if_go_to_label_command = "@SP\nM=M-1\nA=M\nD=M\n@{file_name}.{label_name}\nD; JNE\n"
# 1. @SP                       -- load SP
# 2. M=M-1                     -- reduce SP tp previous cell in stack (SP--)
# 3. A=M                       -- A = M[SP]
# 4. D=M                       -- D = M[M[SP]] (value of top of stack)
# 5. @{file_name}.{label_name} -- load label file_name.label_name into A
# 6. D; JNE                    -- if D != 0 jump to label

# function deceleration (function  function_name  number_of_local_variables)
function_command = "({function_name})\n@{number_of_local_variables}\nD=A\n@{function_name}.End\nD; JEQ\n" \
                   "({function_name}.Loop)\n@SP\nA=M\nM=0\n@SP\nM=M+1\n@{function_name}.Loop\nD=D-1; JNE\n" \
                   "({function_name}.End)\n "
# 1. (function_name)		    -- label with function_name
# 2. @number_of_local_variables	-- load the number of local variables into A
# 3. D=A                        -- D = A (number of local variables)
# 4. @function_name.End		    -- load label function_name.End	into A
# 5. D; JEQ                     -- if D == 0, jump to end (if no local variables jump to end)
# 6. (function_name.Loop)	    -- label function_name.Loop (loop to initialize k local variables with 0)
# 7. @SP                        -- load SP
# 8. A=M                        -- A = M[SP]
# 9. M=0                        -- M[M[SP] = 0 (top of stack = 0)
# 10. @SP                       -- load SP
# 11. M=M+1                     -- M[SP] = M[SP] + 1 (SP points to the next cell in stack)
# 12. @function_name.Loop	    -- load label function_name.Loop into A
# 13. D=D-1; JNE                -- D = D-1 (one variable less), if D != 0 (there are still local variables) jump to loop
# 14. (function_name.End)	    -- label function_name.End

# call function (call  function_name  number of arguments
call_command = "{push_return_address}{push_segment_lcl}{push_segment_arg}{push_segment_this}{push_segment_that}" \
               "@SP\nD=M\n@{function_number_of_arguments}\nD=D-A\n@5\nD=D-A\n@ARG\nM=D\n@SP\nD=M\n@LCL\nM=D\n" \
               "{go_to_function}{return_address_label}" \
    .format(push_return_address=stack_push_constant_command.format(x="{function_name}.ReturnAddress_{x}"),
            push_segment_lcl=stack_push_segment_command.format(segment="LCL"),
            push_segment_arg=stack_push_segment_command.format(segment="ARG"),
            push_segment_this=stack_push_segment_command.format(segment="THIS"),
            push_segment_that=stack_push_segment_command.format(segment="THAT"),
            function_number_of_arguments="{function_number_of_arguments}",
            go_to_function=go_to_label_command.format(label_name="{function_name}"),
            return_address_label=label_command.format(label_name="{function_name}.ReturnAddress_{x}"))
# 1. push_return_address           -- push return address into stack
# 2. push_segment_lcl              -- push lcl into stack
# 3. push_segment_arg              -- push arg into stack
# 4. push_segment_this             -- push this into stack
# 5. push_segment_that             -- push that into stack
# 6. @SP                           -- load SP
# 7. D=M                           -- D = M[SP]
# 8. @function_number_of_arguments -- A = function_number_of_arguments
# 9. D=D-A                         -- D = M[SP] - function_number_of_arguments
# 10. @5                           -- A = 5
# 11. D=D-A                        -- D = M[SP] - function_number_of_arguments - 5 (ths is where function arguments are)
# 12. @ARG                         -- load ARG into A
# 13. M=D                          -- M[ARG] = D
# 14. @SP                          -- load SP
# 15. D=M                          -- D = M[SP]
# 16. @LCL                         -- load LCL into A
# 17. M=D                          -- M[LCL] = D
# 18. go_to_function               -- go to function
# 19. return_address_label         -- create label fro return address

# return from function
return_command = "@LCL\nD=M\n@5\nA=D-A\nD=M\n@14\nM=D\n" \
                 "@SP\nM=M-1\n@SP\nA=M\nD=M\n@ARG\nA=M\nM=D\n" \
                 "@ARG\nD=M+1\n@SP\nM=D\n" \
                 "@LCL\nD=M\n@1\nA=D-A\nD=M\n@THAT\nM=D\n" \
                 "@LCL\nD=M\n@2\nA=D-A\nD=M\n@THIS\nM=D\n" \
                 "@LCL\nD=M\n@3\nA=D-A\nD=M\n@ARG\nM=D\n" \
                 "@LCL\nD=M\n@4\nA=D-A\nD=M\n@LCL\nM=D\n@14\nA=M\n0; JMP"
# 1. @LCL    -- load LCL
# 2. D=M     -- D = M[LCL]
# 3. @5      -- A = 5
# 4. A=D-A   -- A = M[LCL] - 5
# 5. D=M     -- D = M[M[LCL] - 5] (D = return address)
# 6. @14     -- load custom register 14
# 7. M=D     -- M[14] = D (save return address in temp register)
# 8. @SP     -- load SP
# 9. M=M-1   -- M[SP] = M[SP] - 1 (previous cell in stack - return value)
# 10. @SP    -- load AP
# 11. A=M    -- A = M[SP]
# 12. D=M    -- D = M[M[SP]]
# 13. @ARG   -- load ARG into A
# 14. A=M    -- A = M[ARG]
# 15. M=D    -- M[ARG] = D (M[M[SP]]) (save return value in SP of the caller)
# 16. @ARG   -- load ARG
# 17. D=M+1  -- D = M[ARG] + 1
# 18. @SP    -- load SP
# 19. M=D    -- M[SP] = D (M[ARG] + 1) (set SP of caller)
# 20. @LCL   -- load LCL
# 21. D=M    -- D = M[LCL]
# 22. @1     -- load 1 into A
# 23. A=D-A  -- A = M[LCL] - 1 (THAT)
# 24. D=M    -- D = M[M[LCL] - 1]
# 25. @THAT  -- load THAT
# 26. M=D    -- M[THAT] = D (M[M[LCL] - 1]) (restore THAT)
# 27. @LCL   -- load LCL
# 28. D=M    -- D = M[LCL]
# 29. @2     -- load 2 into A
# 30. A=D-A  -- A = M[LCL] - 2 (THIS)
# 31. D=M    -- D = M[M[LCL] - 2]
# 32. @THIS  -- load THIS
# 33. M=D    -- M[THIS] = D (M[M[LCL] - 2]) (restore THIS)
# 34. @LCL   -- load LCL
# 35. D=M    -- D = M[LCL]
# 36. @3     -- load 3 into A
# 37. A=D-A  -- A = M[LCL] - 3 (ARG)
# 38. D=M    -- D = M[M[LCL] - 3]
# 39. @ARG   -- load ARG
# 40. M=D    -- M[ARG] = D (M[M[LCL] - 3]) (restore ARG)
# 41. @LCL   -- load LCL
# 42. D=A    -- D = M[LCL]
# 43. @4     -- load 4 into A
# 44. A=D-A  -- A = M[LCL] - 4 (LCL)
# 45. D=M    -- D = M[M[LCL] - 4]
# 46. @LCL   -- load LCL
# 47. M=D    -- M[LCL] = D (M[M[LCL] - 4]) (restore LCL)
# 48. @14    -- load register 14 (return address)
# 49. A=M    -- A = M[14]
# 50. 0; JMP -- jump to A


# set SP to 256 - the beginning of the stack
stack_init_commands = "@256\nD=A\n@SP\nM=D\n{Sys_init}".format(
                            Sys_init=call_command.format(function_name="Sys.init",
                                                         x="0",
                                                         function_number_of_arguments="0"))
# 1. @256     -- load value 256 to A - begin of stack
# 2. D=A      -- put 256 in register D
# 3. @SP      -- SP to A
# 4. M=D      -- M[0] (==SP) = 256
# 5. Sys_init -- call Sys.init
