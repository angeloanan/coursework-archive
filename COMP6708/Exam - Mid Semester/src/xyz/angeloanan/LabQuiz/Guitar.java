package xyz.angeloanan.LabQuiz;

import java.util.List;

enum GuitarSoundType {
    Bright,
    Warm
}

public abstract class Guitar {
    private final GuitarSoundType soundType;

    public Guitar() {
        final List<GuitarSoundType> soundtypes = List.of(GuitarSoundType.values());

        this.soundType = soundtypes.get((int) Math.floor(Math.random() * soundtypes.size()));
    }

    public void printStats() {
        String statsString = String.join(" - ", getClass().getSimpleName(), soundType.name());
        System.out.println(statsString);
    }
}

