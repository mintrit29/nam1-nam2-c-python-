#include <iostream>
#include <stdio.h>
using namespace std;

struct node
{
    int data; // du lieu cua node =>> du lieu se luu tru
    struct node *pLeft;
    struct node *pRight;
};
typedef struct node NODE;
typedef NODE *TREE;
// khoi tao cay
void KhoiTaoCay(TREE &t)
{
    t = NULL; // cay rong
}
// ham them phan tu x vao cay
void ThemNodeVaoCay(TREE &t, int x)
{
    if (t == NULL)
    {
        NODE *p = new NODE; // khoi tao node
        p->data = x;
        p->pLeft = NULL;
        p->pRight = NULL;
        t = p;
    }
    else
    {
        if (t->data > x)
        {
            ThemNodeVaoCay(t->pLeft, x);
        }
        else if (t->data < x)
        {
            ThemNodeVaoCay(t->pRight, x);
        }
    }
}
// ham xuat cay nhi phan theo NLR
void Duyet_NLR(TREE t)
{
    if (t != NULL)
    {
        cout << t->data << " ";
        Duyet_NLR(t->pLeft);
        Duyet_NLR(t->pRight);
    }
}
// ham kiem tra so nguyen to
bool KiemTraSNT(int x)
{
    if (x < 2)
        return false;
    if (x == 2)
        return true;
    if (x % 2 == 0)
        return false;
    for (int i = 3; i * i <= x; i += 2)
    { // Optimized loop
        if (x % i == 0)
            return false;
    }
    return true;
}

// ham dem so luong so nguyen to
void SoLuongSNT(TREE t, int &dem)
{
    if (t != NULL)
    {
        if (KiemTraSNT(t->data))
        {
            dem++;
        }
        SoLuongSNT(t->pLeft, dem);
        SoLuongSNT(t->pRight, dem);
    }
}
// ham nhap du lieu
void Menu(TREE &t)
{
    while (true)
    {
        cout << "\n--Menu--";
        cout << "\n1.Nhap du lieu";
        cout << "\n2.Xuat du lieu cay theo NLR";
        cout << "\n3.Dem so luong so nguyen to";
        cout << "\n0.Ket thuc chuong trinh";

        int luachon;
        cout << "\nNhap lua chon: ";
        cin >> luachon;
        if (luachon < 0 || luachon > 5)
        {
            cout << "\nLua chon khong hop le";
            system("pause");
        }
        else if (luachon == 1)
        {
            int x;
            cout << "\nNhap so nguyen x";
            cin >> x;
            ThemNodeVaoCay(t, x);
        }
        else if (luachon == 2)
        {
            cout << "\nDuyet cay theo NLR: ";
            Duyet_NLR(t);
        }
        else if (luachon == 3)
        {
            int dem = 0;
            SoLuongSNT(t, dem);
            cout << "\nSo luong so nguyen to la " << dem << endl;
            system("pause");
        }
        else
        {
            break;
        }
    }
}

int main()
{
    TREE t;
    KhoiTaoCay(t);
    Menu(t);
    system("pause");
    return 0;
}