#include <iostream>
using namespace std;

int UCLN(int tu, int mau) {
while (mau != 0) {
int r = tu % mau;
tu = mau;
mau = r;
}
return tu;
}

void RUTGONPHANSO(int &tu, int &mau) {
int ucln = UCLN(tu, mau);
tu /= ucln;
mau /= ucln;
}

void NPS(int &a, int &b) {
    cout << "Nhập vào tử số: ";
    cin >> a;
    cout << "Nhập vào mẫu số: ";
    cin >> b;
}

void XPS(int a, int b) {
    cout << "Phân số: " << a << "/" << b << endl;
}

void TONGPHANSO(int tu1, int mau1, int tu2, int mau2) {
    int tu, mau;
    tu = tu1 * mau2 + tu2 * mau1;
    mau = mau1 * mau2;
    cout << "Tổng hai phân số là: " << tu << "/" << mau << endl;
}

void HIEUPHANSO(int tu1, int mau1, int tu2, int mau2) {
    int tu, mau;
    tu = tu1 * mau2 - tu2 * mau1; 
    mau = mau1 * mau2;
    cout << "Hiệu hai phân số là: " << tu << "/" << mau << endl;
}

void TICHPHANSO(int tu1, int mau1, int tu2, int mau2) {
    int tu, mau;
    tu = tu1 * tu2;
    mau = mau1 * mau2; 
    cout << "Tích hai phân số là: " << tu << "/" << mau << endl;
}

void THUONGPHANSO(int tu1, int mau1, int tu2, int mau2) {
    int tu, mau;
    tu = tu1 * mau2; // Tinh tu so cua thuong
    mau = mau1 * tu2; // Tinh mau so cua thuong
    cout << "Thương hai phân số là: " << tu << "/" << mau << endl;
}

int SOSANHPHANSO(int tu1, int mau1, int tu2, int mau2) {
    int phanSo1 = tu1 * mau2;
    int phanSo2 = tu2 * mau1;
    if (phanSo1 < phanSo2) {
        return -1;
    } else if (phanSo1 > phanSo2) {
        return 1;
    } else {
        return 0;
    }
}

void PHANSOAM(int tu, int mau) {
      if(tu < 0 && mau < 0) {
        cout << "Phân số vừa nhập là số dương" << endl;
    } else if (tu < 0 || mau < 0){
        cout << "Phân số vừa nhập là số âm." << endl;
    } else {
        cout << "Phân số vừa nhập là số dương" << endl;
    }
}

int main() {
    int choice;
    int a, b; 
    do {
        cout << "---Menu---\n";
        cout << "1.Nhập phân số\n";
        cout << "2.Xuất phân số\n";
        cout << "3.Rút gọn phân số\n";
        cout << "4.Tính tổng hai phân số\n";
        cout << "5.Tính hiệu hai phân số\n";
        cout << "6.Tính tích hai phân số\n";
        cout << "7.Tính thương hai phân số\n";
        cout << "8.So sánh hai phân số\n";
        cout << "9.Kiểm tra số âm hay dương\n";
        cout << "0. Thoát\n";
        cout << "Nhập vào lựa chọn của bạn\n";
        cin >> choice;
        switch (choice) {
            case 1:
                NPS(a, b);
                break;
            case 2:
                XPS(a, b);
                break;
            case 3:
                RUTGONPHANSO(a, b);
                cout << "Phân số đã rút gọn: " << a << "/" << b << endl;
                break;
            case 4:
                float x,y,z,v;
                cout << "Nhập tử số thứ 1: ";
                cin >> x;
                cout << "Nhập mẫu số thứ 1: ";
                cin >> y;
                cout << "Nhập tử thứ 2: ";
                cin >> z;
                cout << "Nhập mẫu số thứ 2: ";
                cin >> v;
                TONGPHANSO(x,y,z,v);
                break;
            case 5:
                float X,Y,Z,V;
                cout << "Nhập tử số thứ 1: ";
                cin >> X;
                cout << "Nhập mẫu số thứ 1: ";
                cin >> Y;
                cout << "Nhập tử số thứ 2: ";
                cin >> Z;
                cout << "Nhập mẫu số thứ 2: ";
                cin >> V;
                HIEUPHANSO(X,Y,Z,V);
                break;
            case 6:
                float A,B,C,D;
                cout << "Nhập tử số thứ 1: ";
                cin >> A;
                cout << "Nhập mẫu số thứ 1: ";
                cin >> B;
                cout << "Nhập tử số thứ 2: ";
                cin >> C;
                cout << "Nhập mẫu số thứ 2: ";
                cin >> D;
                TICHPHANSO(A,B,C,D);
                break;
            case 7:
                float A1,B1,C1,D1;
                cout << "Nhập tử số thứ 1: ";
                cin >> A1;
                cout << "Nhập mẫu số thứ 1: ";
                cin >> B1;
                cout << "Nhập tử số thứ 2: ";
                cin >> C1;
                cout << "Nhập mẫu số thứ 2: ";
                cin >> D1;
                THUONGPHANSO(A1,B1,C1,D1);
                break;
            case 8:{
                int tu1,mau1,tu2,mau2;
                cout << "Nhập tử số thứ 1: ";
                cin >> tu1;
                cout << "Nhập mẫu số thứ 1: ";
                cin >> mau1;
                cout << "Nhập tử số thứ 2: ";
                cin >> tu2;
                cout << "Nhập mẫu số thứ 2: ";
                cin >> mau2;
                int ketqua = SOSANHPHANSO(tu1, mau1, tu2, mau2);
    if (ketqua == -1) {
        cout << "Phân số thứ nhất nhỏ hơn phân số thứ hai" << endl;
    } else if (ketqua == 1) {
        cout << "Phân số thứ nhất lớn hơn phân số thứ hai" << endl;
    } else {
        cout << "Hai phân số bằng nhau" << endl;
    }
                break;
            }
            case 9:{
                int tu, mau;
                cout << "Nhập tử số: ";
                cin >> tu;
                cout << "Nhập mẫu số: ";
                cin >> mau;
                PHANSOAM(tu,mau);
                break;
            }
		}
	} while (choice != 0);
}