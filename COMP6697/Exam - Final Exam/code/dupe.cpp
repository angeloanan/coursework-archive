#include <stdio.h>
#include <sys/stat.h>
#include <sys/types.h>

int main(int argc, char const *argv[]) {
  if (argc != 3) {
    printf("Usage: %s <oldname> <newname>\n", argv[0]);
    return 1;
  }

  const char *old_name = argv[1];
  const char *new_name = argv[2];

  // Check if new file exists
  struct stat new_file_stat;
  stat(new_name, &new_file_stat);

  if (S_ISREG(new_file_stat.st_mode)) {
    printf("File %s already exists\n", new_name);
    return 1;
  }

  // Read file and write to new file

  FILE *old_file = fopen(old_name, "r");
  FILE *new_file = fopen(new_name, "w");

  if (old_file == NULL) {
    printf("File %s does not exist\n", old_name);
    return 1;
  }

  if (new_file == NULL) {
    printf("File %s could not be created. Do we have the right permission?\n",
           new_name);
    return 1;
  }

  char c;
  while ((c = fgetc(old_file)) != EOF) {
    fputc(c, new_file);
  }

  fclose(old_file);
  fclose(new_file);

  printf("File %s duplicated to %s\n", old_name, new_name);

  return 0;
}
