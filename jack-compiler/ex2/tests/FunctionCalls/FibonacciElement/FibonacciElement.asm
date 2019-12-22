//bootstrap
@256
D=A
@SP
M=D
@Sys.init.ReturnAddress_0
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
@SP
D=M
@0
D=D-A
@5
D=D-A
@ARG
M=D
@SP
D=M
@LCL
M=D
@Sys.init
0; JMP
(Sys.init.ReturnAddress_0)

//function Main.fibonacci 0
(Main.fibonacci)
@0
D=A
@Main.fibonacci.End
D; JEQ
(Main.fibonacci.Loop)
@SP
A=M
M=0
@SP
M=M+1
@Main.fibonacci.Loop
D=D-1; JNE
(Main.fibonacci.End)
 
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

//push constant 2
@2
D=A
@SP
A=M
M=D
@SP
M=M+1

//lt
@SP
M=M-1
A=M
D=M
A=A-1
D=M-D
@LABEL_0
D;JLT
@SP
A=M-1
M=0
@END_0
0;JMP
(LABEL_0)
@SP
A=M-1
M=-1
(END_0)
 
//if-goto IF_TRUE
@SP
M=M-1
A=M
D=M
@Main.IF_TRUE
D; JNE

//goto IF_FALSE
@Main.IF_FALSE
0; JMP

//label IF_TRUE
(Main.IF_TRUE)

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
//label IF_FALSE
(Main.IF_FALSE)

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

//push constant 2
@2
D=A
@SP
A=M
M=D
@SP
M=M+1

//sub
@SP
M=M-1
A=M
D=M
A=A-1
M=M-D

//call Main.fibonacci 1
@Main.fibonacci.ReturnAddress_0
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
@SP
D=M
@1
D=D-A
@5
D=D-A
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0; JMP
(Main.fibonacci.ReturnAddress_0)

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

//push constant 1
@1
D=A
@SP
A=M
M=D
@SP
M=M+1

//sub
@SP
M=M-1
A=M
D=M
A=A-1
M=M-D

//call Main.fibonacci 1
@Main.fibonacci.ReturnAddress_1
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
@SP
D=M
@1
D=D-A
@5
D=D-A
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0; JMP
(Main.fibonacci.ReturnAddress_1)

//add
@SP
M=M-1
A=M
D=M
A=A-1
M=M+D

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
//function Sys.init 0
(Sys.init)
@0
D=A
@Sys.init.End
D; JEQ
(Sys.init.Loop)
@SP
A=M
M=0
@SP
M=M+1
@Sys.init.Loop
D=D-1; JNE
(Sys.init.End)
 
//push constant 4
@4
D=A
@SP
A=M
M=D
@SP
M=M+1

//call Main.fibonacci 1
@Main.fibonacci.ReturnAddress_2
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
@SP
D=M
@1
D=D-A
@5
D=D-A
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0; JMP
(Main.fibonacci.ReturnAddress_2)

//label WHILE
(Sys.WHILE)

//goto WHILE
@Sys.WHILE
0; JMP
