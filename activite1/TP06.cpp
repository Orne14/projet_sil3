#include <iostream>
using namespace std;

int main() {
    int jr1, mois1, annee1;
    int jr2, mois2, annee2;
    int total1 = 0, total2 = 0;
    int i, jours1, jours2;
    char barre1, barre2, barre3, barre4;

    cout << "Premiere date (jr/mois/annee) : ";
    cin >> jr1 >> barre1 >> mois1 >> barre2 >> annee1;
    cout << "Deuxieme date (jr/mois/annee) : ";
    cin >> jr2 >> barre3 >> mois2 >> barre4 >> annee2;
    if (cin.fail()) {
        cout << "Format de date incorrect.\n";
        return 1;
    }

    if (barre1 != '/' || barre2 != '/' || barre3 != '/' || barre4 != '/') {
        cout << "Format de date incorrect.\n";
        return 1;
    }

    // Nombre de jours du premier mois
    if (mois1 == 2) {
        jours1 = 28;
        if (annee1 % 400 == 0 || (annee1 % 4 == 0 && annee1 % 100 != 0)) {
            jours1 = 29;
        }
    }
    else if (mois1 == 4 || mois1 == 6 || mois1 == 9 || mois1 == 11) {
        jours1 = 30;
    }
    else if (mois1 >= 1 && mois1 <= 12) {
        jours1 = 31;
    }
    else {
        jours1 = 0;
    }

    // Nombre de jours du deuxieme mois
    if (mois2 == 2) {
        jours2 = 28;
        if (annee2 % 400 == 0 || (annee2 % 4 == 0 && annee2 % 100 != 0)) {
            jours2 = 29;
        }
    }
    else if (mois2 == 4 || mois2 == 6 || mois2 == 9 || mois2 == 11) {
        jours2 = 30;
    }
    else if (mois2 >= 1 && mois2 <= 12) {
        jours2 = 31;
    }
    else {
        jours2 = 0;
    }

    // Verification des dates
    if (annee1 <= 0 || annee2 <= 0 || jr1 < 1 || jr1 > jours1
        || jr2 < 1 || jr2 > jours2) {
        cout << "Date invalide.\n";
        return 1;
    }

    // Calcul du nombre de jours avant la premiere date
    for (i = 1; i < annee1; i++) {
        if (i % 400 == 0 || (i % 4 == 0 && i % 100 != 0)) {
            total1 = total1 + 366;
        }
        else {
            total1 = total1 + 365;
        }
    }

    for (i = 1; i < mois1; i++) {
        if (i == 2) {
            if (annee1 % 400 == 0 || (annee1 % 4 == 0 && annee1 % 100 != 0)) {
                total1 = total1 + 29;
            }
            else {
                total1 = total1 + 28;
            }
        }
        else if (i == 4 || i == 6 || i == 9 || i == 11) {
            total1 = total1 + 30;
        }
        else {
            total1 = total1 + 31;
        }
    }
    total1 = total1 + jr1;

    // Calcul du nombre de jours avant la deuxieme date
    for (i = 1; i < annee2; i++) {
        if (i % 400 == 0 || (i % 4 == 0 && i % 100 != 0)) {
            total2 = total2 + 366;
        }
        else {
            total2 = total2 + 365;
        }
    }

    for (i = 1; i < mois2; i++) {
        if (i == 2) {
            if (annee2 % 400 == 0 || (annee2 % 4 == 0 && annee2 % 100 != 0)) {
                total2 = total2 + 29;
            }
            else {
                total2 = total2 + 28;
            }
        }
        else if (i == 4 || i == 6 || i == 9 || i == 11) {
            total2 = total2 + 30;
        }
        else {
            total2 = total2 + 31;
        }
    }
    total2 = total2 + jr2;

    // Difference entre les deux dates
    int difference = total1 - total2;
    if (difference < 0) {
        difference = -difference;
    }

    cout << "Nombre de jours entre les deux dates : " << difference << "\n";
    return 0;
}
