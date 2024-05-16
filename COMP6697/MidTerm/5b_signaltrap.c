#include <signal.h>
#include <stdio.h>

void sigintHandler() {
  printf("Caught SIGINT. Ignoring...\n");
}

int main(void) {
  // At the earliest, handle SIGINT with a custom handler
  signal(SIGINT, sigintHandler);

  while (1) {
    // NOOP: Just here so that main thread doesn't end
  }
  return 0;
}