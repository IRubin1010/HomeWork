def int_try_parse(value):
    try:
        return True, int(value)
    except ValueError:
        return False, value


def map_to_lcl_arg_this_that(value):
    command = ""
    if value == "local":
        command = "LCL"
    elif value == "argument":
        command = "ARG"
    elif value == "this":
        command = "THIS"
    elif value == "that":
        command = "THAT"
    else:
        raise Exception("con not convert {}".format(value))
    return command
