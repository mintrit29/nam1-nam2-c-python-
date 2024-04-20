class Student:
    #class variables
    category = 'Hoc sinh'
    def __init__(self,name):
        self.name = name
    def hello(self):
        print(f'Hello {self.name}')
    def name_lenght(self):
        return len(self.name)
    
    @classmethod
    def info(cls):
        print(f'This is {cls.category}')
student = Student('John')
student.hello()
lenght = student.name_lenght()
print(lenght)
Student.info()