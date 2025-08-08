document.addEventListener('DOMContentLoaded', function() {
    const tableRows = document.querySelectorAll('.cyber-table tbody tr:not(.action-panel-row)');
    
    tableRows.forEach(row => {
        row.addEventListener('contextmenu', function(e) {
            e.preventDefault();
            
            const itemId = this.getAttribute('data-item-id');
            
            const allPanels = document.querySelectorAll('.action-panel-row');
            allPanels.forEach(panel => {
                panel.style.display = 'none';
            });
            
            const actionPanel = document.querySelector(`.action-panel-row[data-item-id="${itemId}"]`);
            if (actionPanel) {
                actionPanel.style.display = 'table-row';
            }
        });
        
        row.addEventListener('click', function(e) {
            if (!e.target.closest('.action-panel')) {
                const itemId = this.getAttribute('data-item-id');
                const actionPanel = document.querySelector(`.action-panel-row[data-item-id="${itemId}"]`);
                if (actionPanel) {
                    actionPanel.style.display = 'none';
                }
            }
        });
    });
    
    document.addEventListener('click', function(e) {
        if (!e.target.closest('.cyber-table')) {
            const allPanels = document.querySelectorAll('.action-panel-row');
            allPanels.forEach(panel => {
                panel.style.display = 'none';
            });
        }
    });
});
