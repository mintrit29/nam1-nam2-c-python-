#include <iostream>
#include <string>
using namespace std;
struct NGAY{
    int ngay;
    int thang;
    int nam;
};
struct SINHVIEN{
    string hoten;
    NGAY ngaysinh;
};

int main(){
SINHVIEN sv1;
sv1.hoten="Tong Minh Triet";
sv1.ngaysinh.ngay=29;
sv1.ngaysinh.thang=10;
sv1.ngaysinh.nam=2004;
int tuoi;
tuoi = 2024 - sv1.ngaysinh.nam;
cout<<"Name: "<<sv1.hoten<<" "<<tuoi<<" Year old"<<endl;
    return 0;
}