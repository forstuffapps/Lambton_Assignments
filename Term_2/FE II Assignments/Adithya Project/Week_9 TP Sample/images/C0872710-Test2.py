# CSD-1233-01
# Test 2
# Sai Sandeep Reddy Dondeti
# C0872710
# 15/12/2022

morse_codes = {
    ' ': ' ',
    ',': '--.--',
    '.': '.-.-.-',
    '?': '..--..',
    '0': '-----',
    '1': '.----',
    '2': '..---',
    '3': '...--',
    '4': '....-',
    '5': '.....',
    '6': '-....',
    '7': '--...',
    '8': '---..',
    '9': '----.',
    'A': '.-',
    'B': '-...',
    'C': '-.-.',
    'D': '-..',
    'E': '.',
    'F': '..-.',
    'G': '--.',
    'H': '....',
    'I': '..',
    'J': '.---',
    'K': '-.-',
    'L': '.-..',
    'M': '--',
    'N': '-.',
    'O': '---',
    'P': '.--.',
    'Q': '--.-',
    'R': '.-.',
    'S': '...',
    'T': '-',
    'U': '..-',
    'V': '...-',
    'W': '.--',
    'X': '-..-',
    'Y': '-.-',
    'Z': '--..'
}


def divide_me(p, q):
    r = p/q
    s = p//q
    t = p % q
    return [r, s, t]


def format_currency(p):
    q = round(p, 2)
    return '{:0,.2f}'.format(q)


def validate_input(p, q):
    for index in q:
        if type(index) != str:
            return False

    for index in range(len(q)):
        q[index] = q[index].lower()

    return p in q


def validate_password(p):
    flag = False
    for index in p:
        if index.isupper() == True:
            flag = True

    if not flag:
        return flag

    flag = False
    for index in p:
        if index.islower() == True:
            flag = True

    if not flag:
        return flag

    flag = False
    for index in p:
        if index.isalnum() == True:
            flag = True

    if not flag:
        return flag

    return len(p) >= 8 and ';' not in p and ' ' not in p


def morse_code(p):

    for index in p:
        if not (index.isalpha() or index.isalnum() or index in ' ,.?'):
            return []

    s = []

    for index in p:
        s.append(morse_codes[index.upper()])

    return s
