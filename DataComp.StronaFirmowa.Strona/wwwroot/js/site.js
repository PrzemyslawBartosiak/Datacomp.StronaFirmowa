export function clearSelection() {
    try {
        const sel = window.getSelection && window.getSelection();
        if (sel && sel.removeAllRanges) sel.removeAllRanges();

        if (document.activeElement && document.activeElement !== document.body) {
            document.activeElement.blur();
        }
    } catch { /* no-op */ }
}