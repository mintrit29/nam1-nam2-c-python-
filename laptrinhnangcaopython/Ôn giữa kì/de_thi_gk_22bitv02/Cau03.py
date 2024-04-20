class Student:
    def __init__(self,name,ap_mark,security_mark,web_mark):
        self.name = name
        self.ap_mark = ap_mark
        self.security_mark = security_mark
        self.web_mark = web_mark
    def __str__(self):
        return f'{self.name},({self.ap_mark},{self.security_mark},{self.web_mark})'
    def diem_tb(self):
        return (self.ap_mark + self.security_mark + self.web_mark) / 3
    def max_diemtb(self):
        return max(self.ap_mark,self.security_mark,self.web_mark)
    
def main():
    students_info = []
    for i in range(25):
        name = input('Nhap vao ten sinh vien: ')
        ap_mark = int(input('Nhap vao diem mon Lap Trinh Nang Cao: '))
        security_mark = int(input('Nhap vao diem mon Bao Mat '))
        web_mark = int(input('Nhap vao diem mon Lap Trinh Web: '))
        student = Student(name,ap_mark,security_mark,web_mark)
        students_info.append(student)
        diem_tb = max(students_info, key=lambda x: x.diem_tb())
        print("Sinh viên có điểm trung bình cao nhất:")
        print(diem_tb)

if __name__ == "__main__":
    main()