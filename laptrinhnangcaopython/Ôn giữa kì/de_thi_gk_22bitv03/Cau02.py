def count_string(str):
    str = input('Nhap vao chuoi')
    in_hoa = 0
    in_thuong = 0
    for i in str:
        if i.islower():
            in_thuong += 1
    print(f'So luong chu in thuong la: {in_thuong}')
    for i in str:
        if i.isupper():
            in_hoa += 1
    print(f'So luong chu in hoa la: {in_hoa}')
count_string(str)
