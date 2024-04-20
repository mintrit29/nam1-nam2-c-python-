# Viết chương trình cho phép nhập vào th��i gian của một công việc nào đó tính b��ng giây. Hãy chuyển đ��i và in ra màn hình th��i gian trên dư��i dạng bao nhiêu gi��, bao nhiêu phút, bao nhiêu giây
time_in_seconds = int(input("Nhập th��i gian (giây): "))

hours = time_in_seconds // 3600
remainder = time_in_seconds % 3600
minutes = remainder // 60
seconds = remainder % 60

print(f"{hours} gi��, {minutes} phút, {seconds} giây")