#! /bin/bash

# Use built in binaries
if ! command -v php &> /dev/null
then
  export PATH=/opt/lampp/bin:$PATH
fi

# Install composer if haven't
if ! command -v composer &> /dev/null
then
  php -r "copy('https://getcomposer.org/installer', 'composer-setup.php');"
  php -r "if (hash_file('sha384', 'composer-setup.php') === '55ce33d7678c5a611085589f1f3ddf8b3c52d662cd01d4ba75c0ee0459970c2200a51f492d557530c71c15d8dba01eae') { echo 'Installer verified'; } else { echo 'Installer corrupt'; unlink('composer-setup.php'); } echo PHP_EOL;"
  php composer-setup.php
  php -r "unlink('composer-setup.php');"
  mv composer.phar /usr/local/bin/composer
fi

# Install nodejs and use pnpm
export PATH="/root/.local/share/fnm:$PATH"
eval "`fnm env`"
if ! command -v fnm &> /dev/null
then
  if ! command -v unzip &> /dev/null
  then
    apt update
    apt install -y zip
  fi

  curl -fsSL https://fnm.vercel.app/install | bash -s -- --skip-shell
  eval "`fnm env`"
  
  fnm install 19
  fnm default 19
fi
