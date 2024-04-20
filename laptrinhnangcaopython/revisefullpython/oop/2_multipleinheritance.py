#Multiple Inheritance
class A:
    def method_a(self):
        print('Method A')
class B:
    def method_b(self):
        print('Method B')
class C(A,B):
    def method_c(self):
        print('Method C')
cobject = C()
cobject.method_a()
cobject.method_b()
cobject.method_c()

#Multi-level inheritance
class A:
    def method_a(self):
        print('Method A')
class B(A):
    def method_b(self):
        print('Method B')
class C(B):
    def method_c(self):
        print('Method C')
cobject = C()
cobject.method_a()
cobject.method_b()
cobject.method_c()