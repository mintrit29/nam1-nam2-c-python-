#include <iostream>
using namespace std;

struct Con_nguoi
{
    Con_nguoi(string ht, int t, float v1, float cc)
    {
        ho_ten = ht;
        tuoi = t;
        vong_mot = v1;
        chieu_cao = cc;
    }
    string ho_ten;
    int tuoi;
    float vong_mot;
    float chieu_cao;
};
int main()
{
    Con_nguoi hoi_phu_nu[3] = 
    {
    Con_nguoi ("thao",22,100,1.68),
    Con_nguoi ("skylar",29,120,1.60),
    Con_nguoi ("sweetie",25,110,1.72),
    };
    
    
    
    Con_nguoi *bo_nhi=nullptr;

    for(int i=0;i<3;i++)
    {
        cout << "Pornstar: " << (hoi_phu_nu[i]).ho_ten << endl;
    }
    return 0;
}