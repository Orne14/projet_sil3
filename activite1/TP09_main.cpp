#include <iostream>
#include "TP09.cpp"
using namespace std;

int main() {
    Point A, B, M;

    A.saisir();
    B.saisir();

    cout << "Point A : ";
    A.affiche();
    cout << "\nPoint B : ";
    B.affiche();
    cout << "\nDistance : " << A.distance(B);

    M = A.milieu(B);
    cout << "\nMilieu : ";
    M.affiche();
    cout << "\n";

    return 0;
}
