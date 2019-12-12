@SP
M=M-1
@X	   -- load value X to A
D=A   -- put X into D
@L    -- load LCL address into A
A=M   -- A = M[LCL]
A=D+A -- A = M[LCL] + X (stored in D)
D=A   -- D = M[LCL] + X



@4
D=M
@2
D=D+A
@13
M=D
@SP
M=M-1
A=M
D=M
@13
A=M
M=D