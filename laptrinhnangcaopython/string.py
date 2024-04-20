#Bài 1 Vòng lặp đếm độ dài chuỗi đã nhập
def dem_so_ki_tu(chuoi: str): #chuỗi :str không có tác dụng thay đổi chuoi
    #print(type(chuoi))
    count=0
    for ki_tu in str(chuoi): #ở đây phải sài đúng str
        count+=1
    print(f"{chuoi} có {count} kí tự")
#Gọi hàm
dem_so_ki_tu(123456) #ra int
dem_so_ki_tu("I love python") # ra str

#Bài 2 Tách chuỗi thành mảng (default phân cách theo khoảng trắng dùng hàm: chuoi.split())
def tach_chuoi(chuoi: str):
    list_chuoi = chuoi.split() # Tách chuỗi thành mảng các từ
    print(list_chuoi)
    print("Số lượng từ trong chuỗi:", len(list_chuoi))

# Test chương trình
chuoi = "Python là một ngôn ngữ lập trình mạnh mẽ"
tach_chuoi(chuoi)

#Bài 3 write a function to count the number of vowels (a e i o u) and consonants in the string
def count_vowels_and_consonants(string):
    vowels = "aeiou"
    # Khởi tạo biến đếm cho nguyên âm và phụ âm
    vowel_count = 0
    consonant_count = 0
    
    # Chuyển đổi chuỗi thành chữ thường để xử lý dễ dàng hơn
    string = string.lower()
    
    # Lặp qua từng ký tự trong chuỗi
    for char in string:
        # Nếu ký tự là một trong các nguyên âm
        if char in vowels:
            vowel_count += 1
        # Nếu ký tự là chữ cái và không phải là nguyên âm, đếm là phụ âm
        elif char.isalpha():
            consonant_count += 1
    
    return vowel_count, consonant_count

# Test chương trình
string = "Hello World"
vowel_count, consonant_count = count_vowels_and_consonants(string)
print("Số lượng nguyên âm:", vowel_count)
print("Số lượng phụ âm:", consonant_count)
