document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.getElementById('sidebar');
    const openBtn = document.getElementById('open_btn');

    openBtn.addEventListener('click', function () {
        sidebar.classList.toggle('open-sidebar');
    });
});
