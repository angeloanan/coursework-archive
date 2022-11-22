package xyz.angeloanan.LabQuiz;

import java.util.List;

enum ElectricGuitarSoundType {
    Funk,
    Jazz,
    Blues,
    Rock
}

public class ElectricGuitar extends Guitar implements ToneControlable, VolumeControlable, SwitchPositionable {
    private final ElectricGuitarSoundType soundType;
    private int switchPos = 0;
    private int tonePos = 0;
    private int volume = 0;

    public ElectricGuitar() {
        final List<ElectricGuitarSoundType> soundtypes = List.of(ElectricGuitarSoundType.values());
        this.soundType = soundtypes.get((int) Math.floor(Math.random() * soundtypes.size()));
    }

    @Override
    public void printStats() {
        String statsString = String.join(" - ", getClass().getSimpleName(), soundType.name(), Integer.toString(tonePos), Integer.toString(volume), Integer.toString(switchPos));
        System.out.println(statsString);
    }

    @Override
    public void setSwitchPosition(int position) {
        this.switchPos = position;
    }

    @Override
    public void setTone(int tone) {
        this.tonePos = tone;
    }

    @Override
    public void setVolume(int volume) {
        this.volume = volume;
    }
}

