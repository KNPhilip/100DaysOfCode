window.playaudio = (sound, id) => {
    var audioPlayer = new Audio(sound);
    audioPlayer.onended = () => {
        if (id !== "") {
            $(`#${id}`).removeClass('highlight');
        }
    }
    audioPlayer.play();
    console.log('play ' + sound)
    if (id !== "") {
        $(`#${id}`).addClass('highlight');
    }
}