async function refreshProducts() {
    await loadProducts();
}

async function addProductModal() {
    $('#addProductModal').modal('show');
    removeErrMsg();

}

$(document).ready(function () {
    $('#btn-add-product').on("click", async function () {
        let modal = $("#addProductModal");
        let description = modal.find('#add-product-description').val();
        let price = modal.find('#add-product-price').val();
        let catagory = modal.find('#add-product-catagory').val();
        let imageUrl = modal.find('#add-product-imageUrl').val();

        if (description === "" || price === "" || catagory === "") {
            removeErrMsg();
            $(".modal-body").prepend(`<p style="color: red" id="errMsg">One or more of the fields is empty. All fields must be filled in</p>`);
        } else {
            let product = {
                description: description,
                price: price,
                catagory: catagory,
                imageUrl: imageUrl
            };

            let res = await fetch("/products/add" + window.location.search, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    product: product,
                })
            });

            if (res.status === 403) {
                removeErrMsg();
                $(".modal-body").prepend(`<p style="color: red" id="errMsg">The product already exists in the system</p>`);
            } else {
                if (res.status !== 200) {
                    if (!$("#errMsg").length) {
                        $(".modal-body").prepend(`<p style="color: red" id="errMsg">an error has occurred please try again</p>`);
                    }
                } else {
                    $('#exampleModal').modal('hide');
                    window.location.reload();
                }
            }
        }
    })
});

// empty modal before exit
$(document).ready(function () {
    $('#addProductModal').on('hide.bs.modal', function () {
        $(".form-control").val('');
        removeErrMsg()
    })
});


function editProduct(caller) {

    let tableRow = $(caller).closest('tr');
    let product = getProductFromRow(tableRow);

    $("#edit-product-description").val(product.description);
    $("#edit-product-price").val(product.price);
    $("#edit-product-catagory").val(product.catagory);
    $("#edit-product-image").attr("src", product.image);

    $('#editProductModal').modal('show');
}

$(document).ready(function () {
    $('#btn-edit-product').on("click", async function () {

        let modal = $("#editProductModal");
        removeErrMsg();
        let description = modal.find('#edit-product-description').val();
        let price = modal.find('#edit-product-price').val();
        let image = modal.find('#edit-product-image').val();
        let catagory = modal.find('#edit-product-catagory').val();

        let updatedProduct = {
            description: description,
            price: price,
            image: image,
            catagory: catagory,
        };

        let res = await fetch("/products/update" + window.location.search, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                updatedProduct: updatedProduct
            })
        });

        if (res.status !== 200) {
            if (!$("#errMsg").length) {
                $(".modal-body").prepend(`<p style="color: red" id="errMsg">an error has occurred please try again</p>`);
            }
        } else {
            $('#exampleModal').modal('hide');
            window.location.reload();
        }
    })
});

// empty modal before exit
$(document).ready(function () {
    $('#editProductModal').on('hide.bs.modal', function () {
        removeErrMsg()
    })
});

function getProductFromRow(row) {
    let product = {};
    let productFieldsArray = [ "image", "description", "price", "catagory"];

    row.find('td').each(function (i) {
        let img = $(this).find("img:first");
        if(img.length > 0)
        {
            let imgSource = img[0].src;
            product[productFieldsArray[i]] = imgSource;
        }
        else{
            let field = $(this).text();
            if (field !== "") {
                product[productFieldsArray[i]] = field;
            }
        }

    });
    return product;
}

function removeErrMsg(){
    if($("#errMsg").length){
        $("#errMsg").remove();
    }
}

