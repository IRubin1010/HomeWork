//bootstrap
@256
D=A
@SP
M=D

//function SimpleFunction.test 2
(SimpleFunction.SimpleFunction.test_0)
@2
D=A
@SimpleFunction.SimpleFunction.test_0.End
D; JEQ
(SimpleFunction.SimpleFunction.test_0.Loop)
@SP
A=M
M=0
@SP
M=M+1
@SimpleFunction.SimpleFunction.test_0.Loop
D=D-1; JNE
(SimpleFunction.SimpleFunction.test_0.End)
 
//push local 0
@0
D=A
@LCL
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//push local 1
@1
D=A
@LCL
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//add
@SP
M=M-1
A=M
D=M
A=A-1
M=M+D

//not
@SP
A=M
A=A-1
M=!M

//push argument 0
@0
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//add
@SP
M=M-1
A=M
D=M
A=A-1
M=M+D

//push argument 1
@1
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//sub
@SP
M=M-1
A=M
D=M
A=A-1
M=M-D

//return
@LCL
D=M
@5
A=D-A
D=M
@14
M=D
@SP
M=M-1
@SP
A=M
D=M
@ARG
A=M
M=D
@ARG
D=M+1
@SP
M=D
@LCL
D=M
@1
A=D-A
D=M
@THAT
M=D
@LCL
D=M
@2
A=D-A
D=M
@THIS
M=D
@LCL
D=M
@3
A=D-A
D=M
@ARG
M=D
@LCL
D=M
@4
A=D-A
D=M
@LCL
M=D
@14
A=M
0; JMP