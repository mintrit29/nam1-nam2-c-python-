#demo định nghĩa hàm
def say_hello(name = 'Triết'):
    print(f'Hello, {name}')

def calculate(x, y):
    return x**y/(x - y)

def _no_accsess_():
    print('Do not print')

if __name__ == '__main__':
    #gọi hàm
    say_hello('Vincent')
    result = calculate(11, 7)
    print('Kết quả tính:', result)