#Bai 4 Tinh diem GPA
'''Nhập 3 cột điểm thành phần (assignment, mid_term, final_exam)
Điểm thành phần từ 0 --> 10
Xuất:
- Điểm TB(final_grade), GPA(điểm số thang 4), GPA_letter (điểm chữ A, B, C, D)
- Xuất file JSON(cấu trúc y chang dict())
{ 'assignment': 8, 'mid_term': 7. 'final_exam': 6, 'final_grade':6, 'GPA': 3.4, 'GPA_letter': 'A'_}
'''

assignment = float(input('Nhập điểm quá trình (20%): '))
mid_term = float(input('Nhập điểm giữa kỳ (20%): '))
final_exam = float(input('Nhập điểm cuối kỳ (60%): '))
final_grade = assignment * 0.2 + mid_term * 0.2 + final_exam *0.6

if final_grade >= 8.5:
    GPA = 'A'
elif final_grade >= 7:
    GPA = 'B'
elif final_grade >= 5.5:
    GPA = 'C'
elif final_grade >= 4:
    GPA = 'D'
else:
    GPA = 'F'
print('Grade:', final_grade, 'GPA:', GPA)
ap = {
    'assignment': assignment,
    'mid_term' : mid_term,
    'final_exam' : final_exam,
    'final_grade' : final_grade,
    'GPA' : GPA
}

import json

with open('grade.txt', 'w') as my_file:
    json.dump(ap, my_file)