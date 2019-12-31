import re

a = "           * The \"Square class implements\" a graphic square. A graphic square"
b = "abcde"
d = a[0:-1]
a = a[0:a.find("implements")]
c = a.startswith("*")
print(b[:1])


def is_integer(number):
    try:
        int_val = int(number)
        return 0 <= int_val <= 32767
    except:
        return False


def is_identifier(word):
    if re.match("^[A-Za-z0-9_]*$", word) and not re.match("^[0-9_]*$", word[:1]):
        return True
    return False


print(is_identifier("a-5"))

