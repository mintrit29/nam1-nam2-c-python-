#include <iostream>
#include <string>
using namespace std;

int main(){

struct SINHVIEN{
string mssv;
string hoten;
int namsinh;
float diem;
};

    SINHVIEN dssv[3];
    for(int i=0; i<3; i++){
        cout<<"Ma so SV: ";
        cin>> dssv[i].mssv;
        cout<<"Ho ten: ";
        cin>> dssv[i].hoten;
    }
//Xuat mssv va ho ten nv
    for(int i=0; i<3; i++){
        cout<<"Sinh vien thu"<<i + 1<<endl;
        cout<<dssv[i].hoten<<endl;
    }
    return 0;
}