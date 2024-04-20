'''Bai01 so lan xuat hien. Doc file/ nhap chuoi tu ban phim. Thong ke so lan xuat hien cua cac tu.'''
import re
chuoi = input("Nhap chuoi: ").strip()

#Xu ly dấu: dùng .replace() của string hoặc re.sub() của Regex
chuoi= re.sub("[?!:,\"]", "", chuoi)
print('Chuoi sau xu ly:', chuoi)

#Tach chuoi thanh mang
mang_tu = chuoi.split() #tach dua tren khoang trang
print(mang_tu)

mang_thong_ke = {} # = {'anh': 3, ' yeu': 4}
for tu in mang_tu:
    #if tu in mang_thong_ke: #Kiem tra tu co nam trong cac keys
    #    mang_thong_ke[tu] += 1
    #else:
    #    mang_thong_ke[tu] = 1
    mang_thong_ke[tu] = mang_thong_ke.get(tu, 0) + 1
print(mang_thong_ke)