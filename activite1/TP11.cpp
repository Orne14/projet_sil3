#include <iostream>
using namespace std;

class Etudiant {
protected:
    char nom[30];
    char prenom[30];
    float tabnotes[10];

public:
    void saisie() {
        cout << "Nom et prenom : ";
        cin >> nom >> prenom;

        for (int i = 0; i < 10; i++) {
            cout << "Note " << i + 1 << " : ";
            cin >> tabnotes[i];
        }
    }

    void affichage() {
        cout << prenom << " " << nom << " - moyenne : " << moyenne() << "\n";
        if (admis() == 1) {
            cout << "Admis\n";
        }
        else {
            cout << "Non admis\n";
        }
    }

    float moyenne() {
        float somme = 0;
        for (int i = 0; i < 10; i++) {
            somme = somme + tabnotes[i];
        }
        return somme / 10;
    }

    int admis() {
        if (moyenne() >= 10) {
            return 1;
        }
        return 0;
    }

    int exae_quo(Etudiant E) {
        if (moyenne() == E.moyenne()) {
            return 1;
        }
        return 0;
    }
};

class Etudiant_en_Maitrise : public Etudiant {
private:
    float note_memoire;

public:
    void saisie() {
        Etudiant::saisie();
        cout << "Note du memoire : ";
        cin >> note_memoire;
    }

    void affichage() {
        cout << prenom << " " << nom << " - moyenne : " << moyenne() << "\n";
        cout << "Note du memoire : " << note_memoire << "\n";
        if (admis() == 1) {
            cout << "Admis\n";
        }
        else {
            cout << "Non admis\n";
        }
    }

    int admis() {
        if (moyenne() >= 10 && note_memoire >= 10) {
            return 1;
        }
        return 0;
    }

    int exae_quo(Etudiant_en_Maitrise E) {
        if (moyenne() == E.moyenne()
            && note_memoire == E.note_memoire) {
            return 1;
        }
        return 0;
    }
};
