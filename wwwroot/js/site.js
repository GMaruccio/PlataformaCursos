// Auto-dismiss toasts
document.querySelectorAll('.toast').forEach(t => {
    setTimeout(() => { t.style.opacity='0'; t.style.transform='translateY(16px)'; t.style.transition='.3s'; setTimeout(()=>t.remove(),300); }, 3500);
});
