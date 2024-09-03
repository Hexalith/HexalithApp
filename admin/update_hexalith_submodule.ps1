# Retour au répertoire parent
cd ..

# Vérifie si le sous-module existe avant de le désinitialiser
if (Test-Path .git\modules\Hexalith) {
    git submodule deinit -f Hexalith

    # Suppression des fichiers liés au sous-module si existent
    rm -Force -Recurse .git\modules\Hexalith
}

# Vérifie si la section submodule.Hexalith existe avant de la supprimer
if (git config -f .gitmodules --name-only --get-regexp '^submodule\.Hexalith$') {
    git config -f .gitmodules --remove-section submodule.Hexalith
    git add .gitmodules
}

# Vérifie si le sous-module est présent dans le cache git avant de le supprimer
if (git ls-files --cached | Select-String 'Hexalith') {
    git rm --cached Hexalith
}

# Vérifie si le répertoire Hexalith existe avant de le supprimer
if (Test-Path Hexalith) {
    rm -Force -Recurse Hexalith
}

# Ajout des changements
git add .

# Commit des changements avec un message
git commit -m "remove hexalith submodule"

# Pousse les changements vers le dépôt distant
git push

# Ajout du sous-module à nouveau
git submodule add https://github.com/Hexalith/Hexalith.git

# Initialisation du sous-module
git submodule init

# Mise à jour du sous-module
git submodule update

# Passage dans le répertoire du sous-module
cd Hexalith

# Checkout de la branche principale
git checkout main

# Retour au répertoire parent
cd ..

# Ajout des changements liés au sous-module
git add .

# Commit des changements avec un message
git commit -m "add hexalith submodule"

# Pousse les changements vers le dépôt distant
git push

# Pause pour garder la console ouverte
pause
