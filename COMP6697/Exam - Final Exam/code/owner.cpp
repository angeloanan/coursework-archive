#include <grp.h>
#include <pwd.h>
#include <stdio.h>
#include <sys/stat.h>
#include <sys/types.h>

int main(int argc, char const *argv[]) {
  if (argc != 2) {
    printf("Usage: %s <filename>\n", argv[0]);
    return 1;
  }

  const char *filename = argv[1];

  // Check if new file exists
  struct stat file_stat;
  stat(filename, &file_stat);

  // If file doesn't exist, return 1
  if (S_ISREG(file_stat.st_mode) == 0) {
    printf("File %s does not exist\n", filename);
    return 1;
  }

  // Get user and group information
  struct passwd *user = getpwuid(file_stat.st_uid);
  struct group *group = getgrgid(file_stat.st_gid);

  printf("File %s is owned by %s:%s\n", filename, user->pw_name,
         group->gr_name);

  return 0;
}
