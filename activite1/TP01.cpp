#include <iostream>
using namespace std;

int main() {
    int An, mois, jour, nbJours;
    bool Bissextile, mois31;

    cout << "Saisir une annee : ";
    cin >> An;

    // Test de l'annee bissextile
    Bissextile = (An % 400 == 0) || ((An % 4 == 0) && (An % 100 != 0));
    if (Bissextile) {
        cout << "L'annee est bissextile\n";
    }
    else {
        cout << "L'annee n'est pas bissextile\n";
    }

    cout << "Saisir le numero du mois (1 a 12) : ";
    cin >> mois;

    // Test du mois a 31 jours
    mois31 = (mois == 1 || mois == 3 || mois == 5 || mois == 7
              || mois == 8 || mois == 10 || mois == 12);
    if (mois31) {
        cout << "Le mois a 31 jours\n";
    }
    else {
        cout << "Le mois n'a pas 31 jours\n";
    }

    cout << "Saisir une date (jour mois annee) : ";
    cin >> jour >> mois >> An;

    // Calcul du nombre de jours dans le mois
    if (mois == 2) {
        if (An % 400 == 0 || (An % 4 == 0 && An % 100 != 0)) {
            nbJours = 29;
        }
        else {
            nbJours = 28;
        }
    }
    else if (mois == 4 || mois == 6 || mois == 9 || mois == 11) {
        nbJours = 30;
    }
    else if (mois >= 1 && mois <= 12) {
        nbJours = 31;
    }
    else {
        nbJours = 0;
    }

    // Verification de la date
    if (An <= 0 || jour < 1 || jour > nbJours) {
        cout << "Date invalide\n";
    }
    else {
        // Calcul du lendemain
        jour++;
        if (jour > nbJours) {
            jour = 1;
            mois++;
            if (mois > 12) {
                mois = 1;
                An++;
            }
        }

        cout << "Le lendemain est : " << jour << "/" << mois << "/" << An << "\n";
    }

    return 0;
}
