function onDetailsRegionIconClick(e) {
    window.location = '/admin/fias/regions/' + e.row.data.Aoguid;
}

function onDetailsAreaIconClick(e) {
    window.location = '/admin/fias/areas/' + e.row.data.Aoguid;
}

function onDetailsCityIconClick(e) {
    window.location = '/admin/fias/cities/' + e.row.data.Aoguid;
}

function onDetailsPlaceIconClick(e) {
    window.location = '/admin/fias/places/' + e.row.data.Aoguid;
}

function onDetailsStreetIconClick(e) {
    window.location = '/admin/fias/streets/' + e.row.data.Aoguid;
}