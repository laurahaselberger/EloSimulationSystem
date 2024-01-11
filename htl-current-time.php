<?php
/*
 * Plugin Name: Current Time Plugin
 * Description: Das Plugin gibt die aktuelle Uhrzeit aus.
 * Version: 0.1
 * Author: Laura Haselberger
 * Author URI: https://htlkrems.ac.at
 */

function AddCurrentTime($content) {
    date_default_timezone_set('Europe/Vienna');
    return $content."<p><em>".date('H:i:s')."</em></p>"; // <Stunden>:<Minuten>:<Sekunden>
}

add_shortcode('current_time', 'AddCurrentTime');
?>