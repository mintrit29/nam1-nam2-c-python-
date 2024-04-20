#BT04_hours.py đọc dữ liệu từ BT04_hours.txt (cùng thư mục)
with open("d:\SCHOOL\CODE\Lập trình nâng cao (Python)\BT04\BT04_hours.txt") as my_file:
    for line in my_file:
        #print(line,end=" ")
        #Suzy ID 123 worked 31.4 hours: 6.3 / day
        items = line.strip().split()
        working_items = items[2:]
        #print(working_items)
        sum = 0
        for item in working_items:
            sum += float(item)
        print(f"{items[1]} ID {items[0]} worked {sum:.2f} hours: {sum/len(working_items):.2f} / day")
