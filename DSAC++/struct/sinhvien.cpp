
#include <iostream>
#include <string>
using namespace std;
struct SINHVIEN{
    string mssv;
    string hoten;
    float diem;
};
int main(){

SINHVIEN sv1;
sv1.mssv="2200004759";
sv1.hoten="Tong Minh Triet";
sv1.diem=10;

SINHVIEN sv2;
sv2.mssv="2200000000";
sv2.hoten="no name";
sv2.diem=8;

float DTB;
DTB = (sv1.diem + sv2.diem) / 2;
cout << "Diem trung binh: " << DTB << endl;

    return 0;
}