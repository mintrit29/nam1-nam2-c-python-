#include <iostream>
using namespace std;

void SelectionSort(int[a], int N)
{
    int min;
    int i, j;
    for(int i=0;i<N-1;i++){
        min = i;
        for(int j=i+1;j<N;j++){
            if(a[j]<a[min]){
                min = j;
            }
    }
        if(min != i){
        swap(a[min], a[i]);
    }
    }
}

int main(){
    
}