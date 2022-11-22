package xyz.angeloanan.LabQuiz;

import java.util.List;

public class AcousticElectricGuitar extends Guitar implements ToneControlable, VolumeControlable {
    private final ElectricGuitarSoundType soundType;
    private int tonePos;
    private int volume;

    public AcousticElectricGuitar() {
        final List<ElectricGuitarSoundType> soundtypes = List.of(ElectricGuitarSoundType.values());
        this.soundType = soundtypes.get((int) Math.floor(Math.random() * soundtypes.size()));
    }

    @Override
    public void printStats() {
        String statsString = String.join(" - ", getClass().getSimpleName(), soundType.name(), Integer.toString(tonePos), Integer.toString(volume));
        System.out.println(statsString);
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
