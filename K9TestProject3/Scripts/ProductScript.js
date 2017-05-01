        function addChildRow() {
            var newRowIndex = $("#children tr.childInfoRow").length;
            var newRow = '<tr><td colspan="3">Child ' + newRowIndex + '</td></tr><tr class="childInfoRow"><td><select id="ColorAttributes[' + newRowIndex + '].ColorId""  name="ColorAttributes[' + newRowIndex + '].ColorId"><option value=""></option></select></td>' +
                '<td><button type="button" id="removeChild' + newRowIndex + '" onclick="removeChildRow(this)">Delete</button></td></tr>' +
                '<td colspan="3">Grandchildren: <br/><button type="button" id="addGrandchild' + newRowIndex + '" onclick="addGrandchildRow(this)">Add Grandchild</button>' +
                '<table id="grandChildren' + newRowIndex + '"><tbody></tbody></table></td></tr>';
            $("#children tbody.childTableBody:last").append(newRow);
        }

        function addGrandchildRow(elem) {
            var childIndex = $(elem).attr('id').replace('addGrandchild', '');
            var newRowIndex = $("#grandChildren" + childIndex + " tr").length;
            var newRow = '<tr><td><input type="text" name="ColorAttributes[' + childIndex + '].SizeAttributes[' + newRowIndex + '].SizeId" /></td>' +
                '<td><input type="text" name="ColorAttributes[' + childIndex + '].SizeAttributes[' + newRowIndex + '].Quantity" /></td>' +
                '<td><button type="button" id="removeGrandchild' + childIndex + '_' + newRowIndex + '" onclick="removeGrandchildRow(this)">Delete</button></td></tr>';
            $("#grandChildren" + childIndex + " tbody:last").append(newRow);
        }
        function removeChildRow(elem) {
            $(elem).closest('tr').prev().remove();
            $(elem).closest('tr').next().remove();
            $(elem).closest('tr').remove();
        }
        function removeGrandchildRow(elem) {
            $(elem).closest('tr').remove();
        }