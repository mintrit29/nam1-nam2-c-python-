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

struct DSSV{
    SINHVIEN sv;
    int n; //so sinh vien
};

DSSV danhsach;
cout<<"Nhap so luong sv: ";
cin>>danhsach.n;

SINHVIEN dssv[danhsach.n];
    for(int i=0; i<danhsach.n; i++){
        cout<<"Ma so SV: ";
        cin>> danhsach.sv[i].mssv;
        cout<<"Ho ten: ";
        cin>> danhsach.sv[i].hoten;
    }
//Xuat mssv va ho ten nv
    for(int i=0; i<danhsach.n; i++){
        cout<<"Sinh vien thu"<<i + 1<<endl;
        cout<<danhsach.sv[i].hoten<<endl;
    }

}