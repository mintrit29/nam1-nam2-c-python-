# Viết chương trình cho phép nhập vào giờ, phút và giây, hãy đổi sang giây và in kết quả ra màn hình
hours = int(input("Nhập giờ: "))
minutes = int(input("Nhập phút: "))
seconds = int(input("Nhập giây: "))

total_seconds = hours * 3600 + minutes * 60 + seconds

print(f"{total_seconds} giây")